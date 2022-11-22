using Microsoft.EntityFrameworkCore;
using SimplePayRollApplication.Context;
using SimplePayRollApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<Employee> GetEmployee(string Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            return employee;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }
    }
}
