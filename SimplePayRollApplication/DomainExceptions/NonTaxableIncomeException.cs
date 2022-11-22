using System;

namespace SimplePayRollApplication.DomainExceptions
{
    public class NonTaxableIncomeException : Exception
    {
        public NonTaxableIncomeException() : base()
        {
                
        }
        
        public NonTaxableIncomeException(string message) : base(message)
        {
                
        }
    }
}
