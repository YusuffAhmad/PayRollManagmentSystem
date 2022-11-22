using SimplePayRollApplication.DTOs;
using SimplePayRollApplication.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Contracts
{
    public interface IUserService
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployee(string userId);
    }
}
