using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.POCO;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using WebApplication2.DTO;

namespace WebApplication2.Areas.Admin
{
    [Area("admin")]
    public class StudentManagementController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentManagementController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string SearchString, int page = 1)
        {
            //Check user role
            var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            var role = await _userManager.GetRolesAsync(currentUser);
            if (!User.Identity.IsAuthenticated || role[0] == "Học Sinh")
            {
                return Redirect("https://localhost:44374");
            }
            var db = _applicationDbContext;
            var user =
                from nd in db.NguoiDungs
                where (!nd.isGV &&
                      (string.IsNullOrEmpty(SearchString) ||
                      (nd.Ho.Contains(SearchString) || nd.Ten.Contains(SearchString))))
                select nd;
            int pageSize = 5;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(user.OrderBy(x => x.MaNgDung), pageSize, page);
            model.RouteValue = new RouteValueDictionary {
                { "SearchString", SearchString}
            };
            return View(model);
        }

        public IActionResult XemThongTinHS(string UserId)
        {
            var hocSinh = _applicationDbContext.NguoiDungs.Where(x => x.MaNgDung == UserId).FirstOrDefault();
            return View(hocSinh);
        }

        public IActionResult ThemHS(string UserId)
        {
            NguoiDung nguoidung = new NguoiDung();
            var itemLast = _applicationDbContext.NguoiDungs.Where(x => !x.isGV).LastOrDefault();
            nguoidung.MaNgDung = AutomaticID(itemLast.MaNgDung, 2);
            return View(nguoidung);
        }

        [HttpPost]
        public IActionResult ThemHocSinh(NguoiDung hocSinh)
        {
            var xeplop = new LopHS()
            {
                UserId = hocSinh.MaNgDung,
                LopId = hocSinh.MaLop
            };
            var addHS = _applicationDbContext.NguoiDungs.Add(hocSinh);
            _applicationDbContext.LopHss.Add(xeplop);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult SuaHocSinh(NguoiDung hocSinh)
        {
            var editHS = _applicationDbContext.NguoiDungs.Update(hocSinh);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public string AutomaticID(string MaHocSinh, int indexKyTuCat)
        {
            string TienTo = MaHocSinh.Substring(0, indexKyTuCat);
            int iSoTang = Convert.ToInt32(MaHocSinh.Substring((MaHocSinh.Length - indexKyTuCat), indexKyTuCat));
            iSoTang++;
            string pMaTongQuat = "";
            if (iSoTang >= 0 && iSoTang < 10)
                pMaTongQuat = TienTo + "000" + iSoTang;
            if (iSoTang >= 10 && iSoTang < 100)
                pMaTongQuat = TienTo + "00" + iSoTang;
            if (iSoTang >= 100 && iSoTang < 1000)
                pMaTongQuat = TienTo + "0" + iSoTang;
            if (iSoTang >= 1000 && iSoTang < 10000)
                pMaTongQuat = TienTo + iSoTang;
            if (iSoTang >= 10000)
                pMaTongQuat = "Không thể tăng hơn nữa";
            return pMaTongQuat;
        }

        public IActionResult DiemSo(string UserId, string hocKy = "HK1")
        {
            var diemHosSinh = _applicationDbContext.Diems
                .Include(x => x.HocKy)
                .Include(x => x.User)
                .Include(x => x.MonHoc)
                .Include(x => x.LoaiDiem)
                .Where(x => x.HocKy.MaHKy == hocKy && x.UserId == UserId).GroupBy(x => x.MonHoc).Select(m =>
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
            var hocluc = _applicationDbContext.HocLucs.ToList();
            if (diemTb >= 8) return "Giỏi";
            if (diemTb >= 6.5 && diemTb < 8) return "Khá";
            if (diemTb < 6.5 && diemTb >= 5) return "Trung bình";
            if (diemTb < 5) return "Yếu";
            return string.Empty;
        }

        public double GetDiemTBHK(List<DiemViewModel> diemViewModel)
        {
            return diemViewModel.Sum(m => m.DiemTb) / diemViewModel.Count;
        }

        [HttpGet]
        public async Task<IActionResult> ViPham(int page = 1)
        {
            var vipham = _applicationDbContext.ViPhams;
            int pageSize = 5;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(vipham.OrderBy(x => x.NgayViPham), pageSize, page);
            model.Action = "ViPham";
            return View(model);
        }
    }

    public class DiemViewModel
    {
        public DiemViewModel()
        {
            DiemDetailViewModels = new List<DiemDetailViewModel>();
        }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public double DiemTb { get; set; }
        public string Xeploai { get; set; }
        public List<DiemDetailViewModel> DiemDetailViewModels { get; set; }
    }

    public class DiemDetailViewModel
    {
        public double Diem { get; set; }
        public string Heso { get; set; }
        public string LoaiDiem { get; set; }
    }

}
