using Atm.Machine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Machine.Services
{
    public  class CalculateCommission : ICalculateCommission
    {
        public   decimal GetCalculatedAmount(decimal amount)
        {
            decimal _result = 0;
            _result = amount + amount / 100;
            _result  = ((decimal)amount) / 100;
            return _result;
        }
    }
}
