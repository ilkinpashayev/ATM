using System;


namespace Atm.Machine.Services.Exceptions
{
    class EmtpyWithdrawAmountException : Exception
    {
        public EmtpyWithdrawAmountException(string message) :
            base(message)
        {

        }
    }
}
