using Atm.Machine.Services.Interfaces;
using Atm.Machine.Services.Menu;
using Castle.Windsor;


namespace Atm.Machine.Services.StrategyPattern
{
    class ReturnCardCommand : ICommand
    {
        public void execute(WindsorContainer container)
        {
            container.Resolve<IATMachine>().ReturnCard();
            var _cardnumber = "";        
            _cardnumber = MenuInsertCard.InsertCard(container);
        }
    }
}
