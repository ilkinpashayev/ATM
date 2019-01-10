using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;
using System.Collections.Generic;


namespace Atm.Machine.Services.StrategyPattern
{
    public class Context
    {
        private static Dictionary<String, ICommand> _strategies = new Dictionary<String, ICommand>();
        static Context()
        {
            _strategies.Add("1", new CardBalanceCommand());
            _strategies.Add("2", new WithdrawAmountCommand());
            _strategies.Add("3", new ReturnCardCommand());
            _strategies.Add(String.Empty, new ExitCardCommand());
        }
        public static void execute(WindsorContainer container, String commandtype)
        {
            _strategies[commandtype].execute(container);
        }

    }
}
