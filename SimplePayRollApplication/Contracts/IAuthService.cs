using SimplePayRollApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task Logout();
        
    }
}
