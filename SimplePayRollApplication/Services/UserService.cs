using Microsoft.AspNetCore.Identity;
using SimplePayRollApplication.Contracts;
using SimplePayRollApplication.DTOs;
using SimplePayRollApplication.Entities;
using SimplePayRollApplication.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaxService _taxService;

        public UserService(IEmployeeRepository employeeRepository, ITaxService taxService)
        {
            _employeeRepository = employeeRepository;
            _taxService = taxService;
        }

        public async Task<EmployeeDto> GetEmployee(string userId)
        {
            var employee = await _employeeRepository.GetEmployee(userId);
            return new EmployeeDto
            {
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName,
                Department = employee.Department,
                Salary = employee.Salary,
                Level = employee.Level,
                IsDeleted = employee.IsDeleted,
                Pension = _taxService.CalculatePension(employee.Salary * 12),
                PAYE = _taxService.CalculateTax(employee.Salary),
                TaxableIncome = _taxService.CalculateTaxableIncome(employee.Salary),
                SalaryAfterTaxDeduction = employee.Salary - _taxService.CalculateTax(employee.Salary)
            };
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return employees.Select(q => new EmployeeDto {
                Id = q.Id,
                Firstname = q.FirstName,
                Lastname = q.LastName,
                Department = q.Department,
                Salary = q.Salary,
                Level = q.Level,
                IsDeleted = q.IsDeleted,
                PAYE = _taxService.CalculateTax(q.Salary),
                TaxableIncome = _taxService.CalculateTaxableIncome(q.Salary),
                SalaryAfterTaxDeduction = q.Salary - _taxService.CalculateTax(q.Salary)
            }).ToList();
        }
    }
}
