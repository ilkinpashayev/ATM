using System;


namespace Atm.Machine.Services.Exceptions
{
    public class CardIsNotInsertedException : Exception
    {
        public CardIsNotInsertedException(string message) :
            base(message)
        {

        }
    }
}
