using SimplePayRollApplication.DomainExceptions;
using SimplePayRollApplication.Services;

namespace SimplePayRollApplication.Tests
{
    [TestFixture]
    public class TaxServiceTests
    {
        private TaxService _taxService; 

        [SetUp]
        public void Setup()
        {
            _taxService = new TaxService();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void CalculateTax_IncomeIsNegativeOrZero_ThrowInvalidIncomeException(decimal income)
        {
            Assert.That(() => _taxService.CalculateTax(income), Throws.Exception.TypeOf<InvalidIncomeException>());
        }

        [Test]
        [TestCase(20000)]
        public void CalculateTax_IncomeIsLessThan30Thousand_ThrowNonTaxableIncomeException(decimal income)
        {
            Assert.That(() => _taxService.CalculateTax(income), Throws.Exception.TypeOf<NonTaxableIncomeException>());
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void CalculateTaxableIncome_IncomeIsNegativeOrZero_ThrowInvalidIncomeException(decimal income)
        {
            Assert.That(() => _taxService.CalculateTaxableIncome(income), Throws.Exception.TypeOf<InvalidIncomeException>());
        }
        
        [Test]
        [TestCase(20000)]
        public void CalculateTaxableIncome_IncomeIsLessThan30Thousand_ThrowNonTaxableIncomeException(decimal income)
        {
            Assert.That(() => _taxService.CalculateTaxableIncome(income), Throws.Exception.TypeOf<NonTaxableIncomeException>());
        }
        
        [Test]
        [TestCaseSource(nameof(IncomeTestsCases))]
        public void CalculateTax_IncomeIsGreaterThanZero_ReturnThePayableTaxAmount(decimal income, decimal expectedResult)
        {
            var result = _taxService.CalculateTax(income);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCaseSource(nameof(TaxableIncomeTestsCases))]
        public void CalculateTaxableIncome_IncomeIsGreaterThanZero_ReturnThePayableTaxAmount(decimal income, decimal expectedResult)
        {
            var result = _taxService.CalculateTaxableIncome(income);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        static readonly object[] IncomeTestsCases =
        {
            new object[] {300000m, 33534.666666666666666666666667m},
            new object[] {9845000m, 1698059.4666666666666666666667m},
        };
        
        static readonly object[] TaxableIncomeTestsCases =
        {
            new object[] {50000m, 241600m},
        };
    }
}