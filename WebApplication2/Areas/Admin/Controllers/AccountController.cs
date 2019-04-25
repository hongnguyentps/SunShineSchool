using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string role ="0")
        {
            var data = _applicationDbContext;
            var roles = data.Roles.ToList();
            var allrole = new List<SelectListItem>
            {
                new SelectListItem {Text = "All", Value = "0"}
            };
            allrole.AddRange(new SelectList(roles, "Id", "Name"));
            ViewBag.AllRole = allrole;
            var account = (from a in data.AppUsers
                join e in data.UserRoles on a.Id equals e.UserId
                join t in data.Roles on e.RoleId equals t.Id
                where role == "0" || e.RoleId == role
                select new ApplicationUser()
                {
                    Ho = a.Ho,
                    Ten = a.Ten,
                    UserName = a.UserName,
                    Email = a.Email,
                    Role = t.Name
                }).ToList();
            return View(account);
        }
    }
}