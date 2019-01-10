using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;


namespace Atm.Machine.Services.Menu
{
    public static class MenuInsertCard
    {
        public static string InsertCard(WindsorContainer container)
        {
            var _cardnumber = "";
            Console.WriteLine("Please enter your card number, or press enter to exit");
            _cardnumber = Console.ReadLine();
            if (string.IsNullOrEmpty(_cardnumber))
            {
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    container.Resolve<IATMachine>().InsertCard(_cardnumber);
                    MenuOperations.DisplayMenuOperations(container);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                    Environment.Exit(0);

                }
            }
            return _cardnumber;
        }
    }
}
