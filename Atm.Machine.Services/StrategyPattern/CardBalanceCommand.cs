using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;


namespace Atm.Machine.Services.StrategyPattern
{
    class CardBalanceCommand : ICommand
    {
        public void execute(WindsorContainer container)
        {
            var cardbalance = container.Resolve<IATMachine>().GetCardBalance();
            Console.WriteLine("Your card balance = " + cardbalance.ToString());

            Menu.MenuOperations.DisplayMenuOperations(container);

        }
    }
}
