using System.Collections.Generic;
using Atm.Machine.Models;


namespace Atm.Machine.Services.Interfaces
{
    public interface IATMachine
    {
        ATMStatus ATMStatus { get; set; }
        string Manufacturer { get; }
        string SerialNumber { get; }
        string ActiveCardNumber { get; set; }
        void InsertCard(string cardNumber);
        decimal GetCardBalance();
        Money WithDrawMoney(int amount);
        void ReturnCard();
        void LoadMoney(Money money);
        IEnumerable<Fee> RetriveChargedFees();
    }
}
