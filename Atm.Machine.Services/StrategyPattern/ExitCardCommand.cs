using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;

namespace Atm.Machine.Services.StrategyPattern
{
    class ExitCardCommand : ICommand
    {
        public void execute(WindsorContainer container)
        {
            Environment.Exit(0);
        }
    }
}
