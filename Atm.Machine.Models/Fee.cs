using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Machine.Models
{
    public struct  Fee
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }

        public decimal WithdrawalFeeAmount { get; set; }

        public DateTime WithdrawalDate { get; set; }



    }
}
