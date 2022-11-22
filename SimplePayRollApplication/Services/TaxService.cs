using SimplePayRollApplication.Contracts;
using SimplePayRollApplication.DomainExceptions;

namespace SimplePayRollApplication.Services
{
    public class TaxService : ITaxService
    {
        private decimal CalculateConsolidationReliefAllowance(decimal G2)
        {
            decimal percentage = 20m / 100m;
            var amount = percentage * G2;
            return amount;
        }

        private decimal CalculateHigherOfNGN(decimal income)
        {
             decimal percentage = 1m / 100m;
            var allowance = percentage * income;
            return allowance > 200000m ? allowance : 200000m;
        }

        public decimal CalculatePension(decimal income)
        {
            if (income <= 0)
                throw new InvalidIncomeException("The income is Less than Or Equal to Zero");
            
            decimal percentage = 8m / 100m;
            var pension = percentage * income;
            return pension;
        }

        public decimal CalculateTax(decimal income)
        {
            if (income <= 0)
            {
                throw new InvalidIncomeException("The income is Less than Or Equal to Zero");
            }
            if (income <= 30000)
            {
                throw new NonTaxableIncomeException("The income is Less than minimum wage");
            }
            
            decimal taxAbleIncome = CalculateTaxableIncome(income);
            decimal tax = 0;
           
            
            if (taxAbleIncome <= 300000)
            {
                return ((7m / 100m) * taxAbleIncome) / 12;
            }
            else if (taxAbleIncome > 300000 && taxAbleIncome <= 3200000)
            {
                if (taxAbleIncome - 300000 <= 300000)
                {
                    tax += (7m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (11m / 100m) * taxAbleIncome;
                    return tax/12;
                }
                if (taxAbleIncome - 300000 <= 800000)
                {
                    tax += (7m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (11m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (15m / 100m) * taxAbleIncome;
                    return tax/12;
                }
                if (taxAbleIncome - 300000 <= 1300000)
                {
                    tax += (7m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (11m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (15m / 100m) * 500000;
                    taxAbleIncome -= 500000;
                    tax += (19m / 100m) * taxAbleIncome;
                    return tax/12;
                }
                if (taxAbleIncome - 300000 <= 2900000)
                {
                    tax += (7m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (11m / 100m) * 300000;
                    taxAbleIncome -= 300000;
                    tax += (15m / 100m) * 500000;
                    taxAbleIncome -= 500000;
                    tax += (19m / 100m) * 500000;
                    taxAbleIncome -= 500000;
                    tax += (21m / 100m) * taxAbleIncome;
                    return tax/12;
                }
            }
            else if (taxAbleIncome > 3200000)
            {
                tax += (7m / 100m) * 300000;
                taxAbleIncome -= 300000;
                tax += (11m / 100m) * 300000;
                taxAbleIncome -= 300000;
                tax += (15m / 100m) * 500000;
                taxAbleIncome -= 500000;
                tax += (19m / 100m) * 500000;
                taxAbleIncome -= 500000;
                tax += (21m / 100m) * 1600000;
                taxAbleIncome -= 1600000;
                tax += (24m / 100m ) * taxAbleIncome;
                return tax /12;
            }

            return tax /12;
        }

        public decimal CalculateTaxableIncome(decimal income)
        {
            if (income <= 0)
            {
                throw new InvalidIncomeException("The income is Less than Or Equal to Zero");
            }
            if (income <= 30000)
            {
                throw new NonTaxableIncomeException("The income is Less than minimum wage");
            }
            income *= 12;
            var pension = CalculatePension(income);
            decimal GrossIncome2 = income - pension; 
            var allowance = CalculateConsolidationReliefAllowance(GrossIncome2);
            var higherOfNGN = CalculateHigherOfNGN(income);

            decimal taxAbleIncome = income - (higherOfNGN + allowance + pension);

            return taxAbleIncome; 
        }
    }
}

