using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Machine.Models
{
    public struct Money
    {
        public int Amount { get; set; }
        public Dictionary<PaperNote,int> Notes { get; set; }
    }
}
