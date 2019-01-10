using Atm.Machine.Models;
using Atm.Machine.Services.Exceptions;
using Atm.Machine.Services.Interfaces;
using Castle.Windsor;
using System;
using System.Collections.Generic;


namespace Atm.Machine.Services.StrategyPatternAdmin
{
    class LoadMoneyCommand: ICommand
    {
        public void execute(WindsorContainer container)
        {
            string eurfiftycount;
            string eurtwentycount;
            string eurtencount;
            string eurfivecount;
            int eurfiftycountint;
            int eurtwentycountint;
            int eurtencountint;
            int eurfivecountint;
            int total;
            Console.WriteLine("Enter number of 50 Eur papernote count:");
            eurfiftycount = Console.ReadLine();
            Console.WriteLine("Enter number of 20 Eur papernote count:");
            eurtwentycount = Console.ReadLine();
            Console.WriteLine("Enter number of 10 Eur papernote count:");
            eurtencount = Console.ReadLine();
            Console.WriteLine("Enter number of 5 Eur papernote count:");
            eurfivecount = Console.ReadLine();
            if (!string.IsNullOrEmpty(eurfiftycount) && !string.IsNullOrEmpty(eurtwentycount) && !string.IsNullOrEmpty(eurtencount) && !string.IsNullOrEmpty(eurfivecount))
            {
                try
                {
                    if (!int.TryParse(eurfiftycount, out eurfiftycountint)
                        || !int.TryParse(eurtwentycount, out eurtwentycountint)
                        || !int.TryParse(eurtencount, out eurtencountint)
                         || !int.TryParse(eurfivecount, out eurfivecountint))
                    {
                        throw new WrongDataEntryException("WrongDataEntryException");
                    }
                    Money _money = new Money();
                    Dictionary<PaperNote, int> _papernotes = new Dictionary<PaperNote, int>();
                    _papernotes.Add(PaperNote.Fifty, eurfiftycountint);
                    _papernotes.Add(PaperNote.Twenty, eurtwentycountint);
                    _papernotes.Add(PaperNote.Ten, eurtencountint);
                    _papernotes.Add(PaperNote.Five, eurfivecountint);
                    total = eurfiftycountint * 50 + eurtwentycountint * 20 + eurtencountint * 10 + eurfivecountint * 5;
                    _money.Notes = _papernotes;
                    _money.Amount = total;
                    container.Resolve<IATMachine>().LoadMoney(_money);
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }

    }
}
