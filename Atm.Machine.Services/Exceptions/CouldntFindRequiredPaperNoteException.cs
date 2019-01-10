using System;


namespace Atm.Machine.Services.Exceptions
{
    public class CouldntFindRequiredPaperNoteException:Exception
    {
        public CouldntFindRequiredPaperNoteException(string message) :
            base(message)
        {

        }
    }
}
