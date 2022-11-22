using SimplePayRollApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Persistence
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string Id);
    }
}
