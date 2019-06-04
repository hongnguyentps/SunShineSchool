using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using WebApplication2.Data;
using WebApplication2.POCO;

namespace WebApplication2.Areas.Admin
{
    [Area("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                // Get the roles for the user
                var role = await _userManager.GetRolesAsync(user);
                if (role[0] == "Admin")
                {
                    return Redirect("/admin/Account");
                }
                if (role[0] == "Giáo Viên")
                {
                    return Redirect("/admin/Lop");
                }
                return Redirect("https://localhost:44374");
            }
            return Redirect("https://localhost:44374/Identity/Account/Login");
        }

        public IActionResult SuKien()
        {
            var thongbao = _applicationDbContext.SuKiens.ToList();
            return View(thongbao);
        }

        public IActionResult ThemSK()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LuuTB(SuKien sukien)
        {
            var user = User.Identity.Name;
            var ngdang = _applicationDbContext.NguoiDungs.Where(x => x.Email == user).Select(y => y.MaNgDung).FirstOrDefault();
            sukien.NgayTao = DateTime.Now;
            sukien.UserId = ngdang;
            _applicationDbContext.SaveChanges();
            _applicationDbContext.SuKiens.Add(sukien);
            return RedirectToAction("SuKien");
        }

        public IActionResult GuiTB()
        {
            var fromAddress = new MailAddress("anhhong2316@gmail.com", "From ng gui");
            var toAddress = new MailAddress("1551010040.hong@gmail.com", "To Ng nhan");
            const string fromPassword = "gmdeptrai";
            const string subject = "Thông báo mới";
            const string body = "Admin vua dang t hong bao moi vao xem di";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return RedirectToAction("SuKien");
        }
    }
}