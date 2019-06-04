using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Pages.Account;
using WebApplication2.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using SparkPostCore;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string role = "0", int page = 1)
        {
            var data = _applicationDbContext;
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            // Get the roles for the user
            var isAdmin = await _userManager.GetRolesAsync(user);
            ViewBag.Role = isAdmin[0];
            if (isAdmin[0] == "Giáo Viên")
            {
                return View("Notice");
            }
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
                           });
            int pageSize = 5;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(account.OrderBy(x => x.NguoiDungId), pageSize, page);
            model.RouteValue = new RouteValueDictionary {
                { "role", role}
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ThemTaiKhoan(RegisterAddingModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                Ho = model.FirstName,
                Ten = model.LastName,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var x = await _userManager.AddToRoleAsync(user, "HocSinh");
            }

            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult GuiMail(string gvEmail)
        {
            var emailFrom = User.Identity.Name;
            var mail = new MailViewModel();
            mail.EmailTo = gvEmail;
            mail.EmailForm = emailFrom;
            return View(mail);
        }

        [HttpPost]
        public async Task<string> SendMai(MailViewModel mail)
        {
            var transmission = new Transmission();
            transmission.Content.From.Email = "testing@sparkpostbox.com";
            transmission.Options.Sandbox = true;
            transmission.Content.Subject = mail.TieuDe;
            transmission.Content.Text = mail.NoiDung;
            transmission.Content.Html = "<html><body><p>" + mail.NoiDung + "</p></body></html>";

            var recipient = new Recipient
            {
                Address = new Address { Email = mail.EmailTo }
            };
            transmission.Recipients.Add(recipient);

            var client = new Client("010b286db2165f3681794521e5f0ce0baaf3e209");
            var result = await client.Transmissions.Send(transmission);
            return string.Empty;
        }
    }
}