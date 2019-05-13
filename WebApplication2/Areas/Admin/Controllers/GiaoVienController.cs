using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using WebApplication2.Data;
using WebApplication2.POCO;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class GiaoVienController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public GiaoVienController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string SearchString, int page = 1)
        {
            var db = _applicationDbContext;
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Role = roles[0];
            if (!User.Identity.IsAuthenticated || roles[0] == "Học Sinh")
            {
                return Redirect("https://localhost:44374");
            }
            var giaovien = from nd in db.NguoiDungs.Include(x => x.LopGvs).Include(x => x.MonHoc)
                where (nd.isGV &&
                      (string.IsNullOrEmpty(SearchString) ||
                      (nd.Ho.Contains(SearchString) || nd.Ten.Contains(SearchString))))
                select new NguoiDung()
                {
                    MaNgDung = nd.MaNgDung,
                    Ho = nd.Ho,
                    Ten = nd.Ten,
                    GioiTinh = nd.GioiTinh,
                    NgaySinh = nd.NgaySinh,
                    MonHoc = nd.LopGvs.Select(x => x.MonHoc.TenMonHoc).FirstOrDefault()
                };
            int pageSize = 5;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(giaovien.OrderBy(x => x.MaNgDung), pageSize, page);
            model.RouteValue = new RouteValueDictionary {
                { "SearchString", SearchString}
            };
            return View("GiaoVien", model);
        }

        public IActionResult XemThongTinGV(string UserId)
        {
            var giaoVien = _applicationDbContext.NguoiDungs.Where(x => x.MaNgDung == UserId).FirstOrDefault();
            return View(giaoVien);
        }

        [HttpPost]
        public IActionResult SuaGV(NguoiDung giaovien)
        {
            giaovien.isGV = true;
            var editGV = _applicationDbContext.NguoiDungs.Update(giaovien);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult ThemGV(string UserId)
        {
            NguoiDung nguoidung = new NguoiDung();
            var itemLast = _applicationDbContext.NguoiDungs.Where(x => x.isGV).LastOrDefault();
            nguoidung.MaNgDung = AutomaticID(itemLast.MaNgDung, 2);
            return View(nguoidung);
        }

        [HttpPost]
        public IActionResult ThemGiaoVien(NguoiDung giaovien)
        {
            var addGV = _applicationDbContext.NguoiDungs.Add(giaovien);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public string AutomaticID(string MaGiaoVien, int indexKyTuCat)
        {
            string TienTo = MaGiaoVien.Substring(0, indexKyTuCat);
            int iSoTang = Convert.ToInt32(MaGiaoVien.Substring((MaGiaoVien.Length - indexKyTuCat), indexKyTuCat));
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
    }
}