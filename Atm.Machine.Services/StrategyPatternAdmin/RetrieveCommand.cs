using Atm.Machine.Models;
using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;
using System.Collections.Generic;


namespace Atm.Machine.Services.StrategyPatternAdmin
{
    class RetrieveCommand : ICommand
    {
        public void execute(WindsorContainer container)
        {
            IEnumerable<Fee> _feelist = container.Resolve<IATMachine>().RetriveChargedFees();
            int zz = 0;
            foreach (var item in _feelist)
            {
                Console.WriteLine("Cardnumber= " + item.CardNumber + "|| WithdrawalDate " + item.WithdrawalDate + "|| WithdrawalFeeAmount " + item.WithdrawalFeeAmount);
            }

        }
    }
    
}
