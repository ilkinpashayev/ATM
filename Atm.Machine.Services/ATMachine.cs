using Atm.Machine.Models;
using Atm.Machine.Services.Exceptions;
using Atm.Machine.Services.Interfaces;
using System;
using System.Collections.Generic;
using Atm.Machine.Infrastructure;
using Atm.Machine.Services;
using System.Text;

namespace Atm.Machine.Services
{
    public class ATMachine : IATMachine
    {
        private string _manufacturer = "Wincor";
        private string _serialnumber = "WC989820199";
        private string _activecardnumber;
        public virtual ATMStatus _atmstatus { get; internal set; }
        public virtual ATMExecuteStatus _atmexecutestatus { get; internal set; }
        string IATMachine.ActiveCardNumber
        {
            get { return _activecardnumber; }
            set { _activecardnumber = value; }
        }
        ATMStatus IATMachine.ATMStatus 
        {
            get { return _atmstatus; }
            set { _atmstatus = value; }
        }
        string IATMachine.Manufacturer
        {
            get { return _manufacturer; }
        }
        string IATMachine.SerialNumber
        {
            get { return _serialnumber; }
        }
        public ATMachine()
        {
        }
        public void InsertCard(string cardNumber)
        {
            if (_atmstatus == ATMStatus.READY)
            {
                _atmstatus = ATMStatus.CARDINSERTED;
                _activecardnumber = cardNumber;
                DBHelper _dbhelper = new DBHelper();
                _dbhelper.RegisterCard(cardNumber);
            }
            else
            {
                throw new CardIsInsertedException("CardIsInserted");
            }
            _atmstatus = ATMStatus.CARDINSERTED;
        }
        public decimal GetCardBalance()
        {
            decimal _val = 0;
            if (_atmstatus == ATMStatus.CARDINSERTED)
            {
                DBHelper _dbhelper = new DBHelper();
                _val = _dbhelper.GetCardBalance(this._activecardnumber);
            }
            else
            {
                throw new CardIsNotInsertedException("CardIsNotInserted");
            }
            return _val;
        }
        public Money WithDrawMoney(int amount)
        {
            PaperNoteCount _papernotecount = new PaperNoteCount();
            if (_atmstatus == ATMStatus.CARDINSERTED)
            {
                CalculateCommission _calculateCommission = new CalculateCommission();
                decimal getcalcamount = _calculateCommission.GetCalculatedAmount(amount);
                decimal cardbalance = GetCardBalance();
                if (cardbalance >= getcalcamount)
                {
                    Money _money = new Money();
                    _money = _papernotecount.GetPaperNoteCount(amount);
                    if (_money.Amount != amount)
                    {
                        throw new CouldntFindRequiredPaperNoteException("CouldntFindRequiredPaperNote");
                    }
                    else
                    {
                        DBHelper _dbhelper = new DBHelper();
                        _dbhelper.SetCardBalance(this._activecardnumber, getcalcamount+amount, cardbalance);
                        _dbhelper.AddFeeHistory(this._activecardnumber, getcalcamount);
                        return _money;
                    }
                }
                else
                {
                    throw new NotEnoughBalanceException("NotEnoughBalance");
                }
            }
            else
            {
                throw new CardIsNotInsertedException("CardIsNotInserted");
            }
        }

        public void ReturnCard()
        {
            string tempcardnumber = this._activecardnumber;
            if (_atmstatus == ATMStatus.CARDINSERTED)
            {
                _atmstatus = ATMStatus.CARDINSERTED;
                _activecardnumber = null;

            }
            else
            {
                throw new CardIsNotInsertedException("CardIsNotInserted");
            }
            _atmstatus = ATMStatus.READY;
        }

        public void LoadMoney(Money money)
        {
            try
            {
                DBHelperBackend _dbhelper = new DBHelperBackend();
                _dbhelper.LoadMoney(this._serialnumber, this._manufacturer, money);
                _atmexecutestatus = ATMExecuteStatus.DONE;
            }
            catch(Exception ex)
            {
                _atmexecutestatus = ATMExecuteStatus.ERROR;
            }
        }

        public IEnumerable<Fee> RetriveChargedFees()
        {
            IEnumerable<Fee> _return ;
            DBHelperBackend _dbhelper = new DBHelperBackend();
            _return = _dbhelper.GetWithdralFeeHistory();
            return _return;
        }
    }
}
