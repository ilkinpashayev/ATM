using Atm.Machine.Services.StrategyPattern;
using Castle.Windsor;
using System;


namespace Atm.Machine.Services.Menu
{
    public static class MenuOperations
    {
        public static string DisplayMenuOperations(WindsorContainer container)
        {
            var _menuitem = "";
            Console.WriteLine("Type 1 to view Cardbalance ");
            Console.WriteLine("Type 2 to view Withdraw");
            Console.WriteLine("Type 3 to Return Card");
            Console.WriteLine("Press enter to exit");
            _menuitem = Console.ReadLine();
            try
            {
                Context.execute(container, _menuitem);
            }
            catch (Exception ex)
            {
                DisplayMenuOperations(container);
            }
            return _menuitem;
        }

    }
}
