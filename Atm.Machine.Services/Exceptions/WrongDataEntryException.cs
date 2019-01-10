using System;


namespace Atm.Machine.Services.Exceptions
{
    public class WrongDataEntryException:Exception
    {
        public WrongDataEntryException(string message) :
            base(message)
        {

        }
    }

}
