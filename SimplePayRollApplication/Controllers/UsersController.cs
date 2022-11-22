using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using SimplePayRollApplication.Contracts;
using SimplePayRollApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePayRollApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var employees = await  _userService.GetEmployees();
            return View(employees);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            if (ModelState.IsValid)
            {
                string returnUrl = Url.Content("~/");
                var isLoggedIn = await _authService.Login(request);
                    return RedirectToAction(nameof(Dashboard));
            }
            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(request);
        }

       
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
