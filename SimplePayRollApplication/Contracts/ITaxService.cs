namespace SimplePayRollApplication.Contracts
{
    public interface ITaxService
    {
        decimal CalculateTax(decimal income);
        decimal CalculateTaxableIncome(decimal income);
        decimal CalculatePension(decimal income);
    }

}

