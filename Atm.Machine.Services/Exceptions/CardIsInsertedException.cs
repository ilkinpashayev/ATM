using System;


namespace Atm.Machine.Services.Exceptions
{
    public class CardIsInsertedException:Exception
    {
        public CardIsInsertedException(string message) :
            base(message)
        {

        }
    }
}
