using Atm.Machine.Services.Interfaces;
using Atm.Machine.Services.StrategyPattern;
using Castle.Windsor;
using System;
using System.Collections.Generic;

namespace Atm.Machine.Services.StrategyPatternAdmin
{
    class ContextAdmin
    {
        private static Dictionary<String, ICommand> _strategies = new Dictionary<String, ICommand>();
        static ContextAdmin()
        {
            _strategies.Add("1", new LoadMoneyCommand());
            _strategies.Add("2", new RetrieveCommand());
            _strategies.Add(String.Empty, new ExitCardCommand());
        }
        public static void execute(WindsorContainer container, String commandtype)
        {
            _strategies[commandtype].execute(container);
        }
    }
}
