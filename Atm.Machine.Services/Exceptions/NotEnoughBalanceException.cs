using System;


namespace Atm.Machine.Services.Exceptions
{
    public class NotEnoughBalanceException:Exception
    {
        public NotEnoughBalanceException(string message) :
            base(message)
        {

        }
    }
}
