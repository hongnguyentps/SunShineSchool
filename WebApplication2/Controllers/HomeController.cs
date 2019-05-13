using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using WebApplication2.Areas.Admin;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.POCO;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
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
                var isAdmin = await _userManager.GetRolesAsync(user);
                ViewBag.Role = isAdmin[0];
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult XemLop()
        {
            var emailHS = User.Identity.Name;
            var idHs = _applicationDbContext.NguoiDungs.Where(x => x.Email == emailHS).FirstOrDefault();
            var lopTungHoc = _applicationDbContext.LopHss.Include(x => x.Lop)
                                                         .Include(x => x.User)
                                                         .Include(x => x.Lop.Khoi)
                                                         .Include(x => x.Lop.NienKhoa)
                                                         .Where(x => x.UserId == idHs.MaNgDung).ToList();
            return View(lopTungHoc);
        }

        public async Task<IActionResult> XemDiem(string UserId, string LopId, string hocKy = "HK1")
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var isAdmin = await _userManager.GetRolesAsync(user);
            ViewBag.Role = isAdmin[0];
            var diemHosSinh = _applicationDbContext.Diems
                .Include(x => x.HocKy)
                .Include(x => x.User)
                .Include(x => x.MonHoc)
                .Include(x => x.LoaiDiem)
                .Where(x => x.HocKy.MaHKy == hocKy && x.UserId == UserId && x.LopId == LopId).GroupBy(x => x.MonHoc).Select(m =>
                    new DiemViewModel()
                    {
                        MaMH = m.Key.MaMH,
                        TenMH = m.Key.TenMonHoc,
                        DiemDetailViewModels = m.Select(x => new DiemDetailViewModel()
                        {
                            Diem = x.DiemSo,
                            Heso = x.LoaiDiem.HeSo,
                            LoaiDiem = x.LoaiDiemId
                        }).ToList()
                    }).ToList();
            foreach (var data in diemHosSinh)
            {
                var tongDiem = data.DiemDetailViewModels.Sum(m => m.Diem * int.Parse(m.Heso));
                var tongHeso = data.DiemDetailViewModels.Sum(m => int.Parse(m.Heso));
                data.DiemTb = tongDiem / tongHeso;
                data.Xeploai = GetXepLoai(data);
               
            }

            ViewBag.LopId = LopId;
            ViewBag.UserId = UserId;
            ViewBag.HocKy = hocKy;
            ViewBag.DiemTBHocKy = GetDiemTBHK(diemHosSinh);
            ViewBag.XepLoaiHocKy = XepLoai(GetDiemTBHK(diemHosSinh));
            return View(diemHosSinh);
        }

        private string GetXepLoai(DiemViewModel diemViewModel)
        {
            return XepLoai(diemViewModel.DiemTb);
        }

        private string XepLoai(double diemTb)
        {
            if (diemTb >= 8) return "Giỏi";
            if (diemTb >= 7 && diemTb < 8) return "Khá";
            if (diemTb < 7 && diemTb >= 5) return "Trung bình";
            if (diemTb < 5) return "Yếu";
            return string.Empty;
        }

        public double GetDiemTBHK(List<DiemViewModel> diemViewModel)
        {
            return diemViewModel.Sum(m => m.DiemTb) / diemViewModel.Count;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> XemViPham()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var isAdmin = await _userManager.GetRolesAsync(user);
            ViewBag.Role = isAdmin[0];
            var emailHS = User.Identity.Name;
            var idHs = _applicationDbContext.NguoiDungs.Where(x => x.Email == emailHS).FirstOrDefault();
            var vipham = _applicationDbContext.ViPhams
                .Include(x => x.Hs)
                .Where(x => x.HsId == idHs.MaNgDung).OrderBy(x => x.NgayViPham).ToList();
            return View(vipham);
        }
    }
}
