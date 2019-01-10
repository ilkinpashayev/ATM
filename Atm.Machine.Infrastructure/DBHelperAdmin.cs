using Atm.Machine.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Atm.Machine.Infrastructure
{
    public class DBHelperAdmin
    {
        private string DBLocation { get; set; }
        public DBHelperAdmin()
        {
            DBLocation = ConfigurationManager.AppSettings["LiteDB"];
        }

        public IEnumerable<Fee> GetWithdralFeeHistory()
        {
            List<Fee> _return = new List<Fee>();
            using (var db = new LiteDatabase(DBLocation))
            {
                var _WithdrawalHistory = db.GetCollection<Fee>("WithdrawalHistory");
                var results = _WithdrawalHistory.FindAll();
                if (results.Count() > 0)
                {
                    foreach (var _result in results)
                    {
                        _return.Add(new Fee() { CardNumber = _result.CardNumber, WithdrawalDate = _result.WithdrawalDate, WithdrawalFeeAmount = _result.WithdrawalFeeAmount });
                    }
                }

            }
            return _return;
        }
        public int GetATMBalance(string serialnumber)
        {
            int atmbalance = 0;
            using (var db = new LiteDatabase(DBLocation))
            {
                var _ATMInfo = db.GetCollection<ATMInfo>("ATMDetails");
                var results = _ATMInfo.Find(x => x.SerialNumber.Equals(serialnumber));
                if (results.Count() > 0)
                {
                    foreach (var _result in results)
                    {
                        atmbalance = _result.ATMBalance;
                    }
                }
            }
            return atmbalance;
        }


        public void LoadMoney(string serialnumber, string manufacturer, Money money)
        {
            int loadtotal = 0;
            int atmcurrentbalance = 0;
            Money _newmoney;
            using (var db = new LiteDatabase(@"c:\temp\MyData.db"))
            {
                var _ATMInfo = db.GetCollection<ATMInfo>("ATMDetails");
                var results = _ATMInfo.Find(x => x.SerialNumber.Equals(serialnumber));
                if (results.Count() == 0)
                {
                    var newATMInfo = new ATMInfo
                    {
                        SerialNumber = serialnumber,
                        ATMBalance = money.Amount,
                        Money = money
                    };
                    _ATMInfo.Insert(newATMInfo);
                }
                else
                {
                    _newmoney = new Money();
                    Dictionary<PaperNote, int> _papernotes = new Dictionary<PaperNote, int>();
                    Money atmcurrentmoney;
                    foreach (var _result in results)
                    {
                        atmcurrentmoney = _result.Money;
                        atmcurrentbalance = _result.ATMBalance;

                        foreach (var _obj in atmcurrentmoney.Notes)
                        {
                            switch (_obj.Key.ToString())
                            {
                                case "Five":
                                    _papernotes.Add(PaperNote.Five, _obj.Value + money.Notes[PaperNote.Five]);
                                    loadtotal = loadtotal + money.Notes[PaperNote.Five] * 5;
                                    break;
                                case "Ten":
                                    _papernotes.Add(PaperNote.Ten, _obj.Value + money.Notes[PaperNote.Ten]);
                                    loadtotal = loadtotal + money.Notes[PaperNote.Ten] * 10;
                                    break;
                                case "Twenty":
                                    _papernotes.Add(PaperNote.Twenty, _obj.Value + money.Notes[PaperNote.Twenty]);
                                    loadtotal = loadtotal + money.Notes[PaperNote.Twenty] * 20;
                                    break;
                                case "Fifty":
                                    _papernotes.Add(PaperNote.Fifty, _obj.Value + money.Notes[PaperNote.Fifty]);
                                    loadtotal = loadtotal + money.Notes[PaperNote.Fifty] * 50;
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    loadtotal = loadtotal + atmcurrentbalance;
                    _newmoney.Notes = _papernotes;
                    _newmoney.Amount = loadtotal;
                    foreach (var _result in results)
                    {
                        _result.ATMBalance = loadtotal;
                        _result.Money = _newmoney;
                        _result.SerialNumber = serialnumber;

                        _ATMInfo.Update(_result);
                    }
                }
            }
        }


    }
}
