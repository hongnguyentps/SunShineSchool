using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Areas.Admin
{
    [Area("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                // Get the roles for the user
                var role = await _userManager.GetRolesAsync(user);
                if (role[0] == "Admin" || role[0] == "Giáo Viên")
                {
                    return Redirect("/admin/Account");
                }
                return Redirect("https://localhost:44374");
            }
            return Redirect("https://localhost:44374/Identity/Account/Login");
        }
    }
}