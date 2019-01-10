using Atm.Machine.Models;
using LiteDB;
using System;
using System.Linq;

namespace Atm.Machine.Infrastructure
{
    public class DBHelper
    {
        public DBHelper()
        {

        }

        public void RegisterCard(string cardnumber)
        {

            using (var db = new LiteDatabase(@"c:\temp\MyData.db"))
            {

                var _Cardinfo = db.GetCollection<CardInfo>("CardDetail");

                var results = _Cardinfo.Find(x => x.CardNumber.Equals(cardnumber));

                if (results.Count() == 0)
                {

                    var newcrdInfo = new CardInfo
                    {
                        CardNumber = cardnumber,
                        Total = 1000
                    };


                    _Cardinfo.Insert(newcrdInfo);
                }

            }
        }


        public decimal GetCardBalance(string cardnumber)
        {

            decimal cardbalance = 0;
            using (var db = new LiteDatabase(@"c:\temp\MyData.db"))
            {

                var _Cardinfo = db.GetCollection<CardInfo>("CardDetail");

                var results = _Cardinfo.Find(x => x.CardNumber.Equals(cardnumber));

                if (results.Count() > 0)
                {
                    foreach (var _result in results)
                    {
                        cardbalance = _result.Total;
                    }
                }

            }
            return cardbalance;

        }

        public void SetCardBalance(string cardnumber, decimal withdrawAmount, decimal cardbalance)
        {

            using (var db = new LiteDatabase(@"c:\temp\MyData.db"))
            {

                // Get customer collection
                var cards = db.GetCollection<CardInfo>("CardDetail");
                var defaultcard = cards.Find(x => x.CardNumber.Equals(cardnumber));

                foreach (var _result in defaultcard)
                {
                    _result.Total = cardbalance - withdrawAmount;
                    cards.Update(_result);
                }


            }
        }
        public void AddFeeHistory(string cardnumber, decimal withdrawlfeeamount)
        {

            using (var db = new LiteDatabase(@"c:\temp\MyData.db"))
            {

                var _WithdrawalHistory = db.GetCollection<Fee>("WithdrawalHistory");

                var results = _WithdrawalHistory.Find(x => x.CardNumber.Equals(cardnumber));
                var newFee = new Fee
                {
                    CardNumber = cardnumber,
                    WithdrawalDate = DateTime.Now,
                    WithdrawalFeeAmount = withdrawlfeeamount
                };
                _WithdrawalHistory.Insert(newFee);
            }
        }


    }

}
