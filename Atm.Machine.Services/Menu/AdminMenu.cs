using Atm.Machine.Services.StrategyPatternAdmin;
using Castle.Windsor;
using System;


namespace Atm.Machine.Services.Menu
{
    public static class AdminMenu
    {
        public static void DisplayAdminMenu(WindsorContainer container)
        {
            var _menuitem = "";
            Console.WriteLine("1-Load money to ATM");
            Console.WriteLine("2-Retrieve charged fees");
            _menuitem = Console.ReadLine();
            try
            {
                ContextAdmin.execute(container, _menuitem);
            }
            catch (Exception ex)
            {
                DisplayAdminMenu(container);
            }

        }
    }
}
