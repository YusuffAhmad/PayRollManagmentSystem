using System;

namespace SimplePayRollApplication.DomainExceptions
{
    public class InvalidIncomeException : Exception
    {
        public InvalidIncomeException() : base ()
        {
                
        }
        public InvalidIncomeException(string message) : base (message)
        {
                
        }
    }
}
