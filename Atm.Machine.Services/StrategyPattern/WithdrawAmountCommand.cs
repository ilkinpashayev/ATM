using Atm.Machine.Services.Exceptions;
using Atm.Machine.Services.Interfaces;
using Atm.Machine.Services.Menu;
using Castle.Windsor;
using System;

namespace Atm.Machine.Services.StrategyPattern
{
    class WithdrawAmountCommand : ICommand
    {
        public void execute(WindsorContainer container)
        {
            var _withdrawamount = "";
            Console.WriteLine("Please enter amount:");
            _withdrawamount = Console.ReadLine();

            if (string.IsNullOrEmpty(_withdrawamount))
            {
                container.Resolve<IATMachine>().ReturnCard();
                throw new EmtpyWithdrawAmountException("WithdrawAmountisNull");
            }
            else
            {
                try
                {
                    var money = container.Resolve<IATMachine>().WithDrawMoney(Convert.ToInt32(_withdrawamount));
                    foreach (var _obj in money.Notes)
                    {
                        Console.WriteLine(_obj.Key.ToString() + " " + _obj.Value.ToString());
                    }
                    container.Resolve<IATMachine>().ReturnCard();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    container.Resolve<IATMachine>().ReturnCard();
                }
            }
            Console.ReadLine();
            var _cardnumber = "";
            _cardnumber = MenuInsertCard.InsertCard(container);
        }
    }
}
