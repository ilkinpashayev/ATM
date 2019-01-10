using Atm.Machine.Models;
using Atm.Machine.Services.Interfaces;
using System.Collections.Generic;


namespace Atm.Machine.Services
{
    public  class PaperNoteCount: IPaperNoteCount
    {
        public  Money GetPaperNoteCount(int amount)
        {
            int calcamount = amount;
            Money _money = new Money();
            Dictionary<PaperNote, int> _dict = new Dictionary<PaperNote, int>();
            

            int[] notes = new int[] { 50, 20, 10, 5 };
            int[] noteCounter = new int[4];

            for (int i = 0; i < 4; i++)
            {
                if (calcamount >= notes[i])
                {
                    noteCounter[i] = calcamount / notes[i];
                    if (i == 0 && noteCounter[i] > 0)
                    {
                        _dict.Add(PaperNote.Fifty, noteCounter[i]);
                    }
                    if (i == 1 && noteCounter[i] > 0)
                    {
                        _dict.Add(PaperNote.Twenty, noteCounter[i]);
                    }
                    if (i == 2 && noteCounter[i] > 0)
                    {
                        _dict.Add(PaperNote.Ten, noteCounter[i]);
                    }
                    if (i == 3 && noteCounter[i] > 0)
                    {
                        _dict.Add(PaperNote.Five, noteCounter[i]);
                    }
                    calcamount = calcamount - noteCounter[i] * notes[i];
                }
            }
            _money.Amount = amount - calcamount;
            _money.Notes = _dict;
            return _money;
        }

    }


}
