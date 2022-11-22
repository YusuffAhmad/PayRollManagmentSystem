namespace SimplePayRollApplication.DTOs
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public int Level { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal PAYE { get; set; }
        public decimal Pension { get; set; }
        public decimal SalaryAfterTaxDeduction { get; set; }
    }
}
