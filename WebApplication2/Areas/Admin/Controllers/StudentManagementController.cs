using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.POCO;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace WebApplication2.Areas.Admin
{
    [Area("admin")]
    public class StudentManagementController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentManagementController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index(string SearchString, int page = 1)
        {
            var user =
                from s in _applicationDbContext.NguoiDungs
                where (!s.isGV &&
                      (string.IsNullOrEmpty(SearchString) ||
                      (s.Ho.Contains(SearchString) || s.Ten.Contains(SearchString))))
                select s;
            int pageSize = 5;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(user.OrderBy(x=> x.MaNgDung), pageSize, page);
            model.RouteValue = new RouteValueDictionary {
                { "SearchString", SearchString}
            };
            return View(model);
        }

        public IActionResult XemThongTinHS(string UserId)
        {
            var hocSinh = _applicationDbContext.NguoiDungs.Where(x => x.MaNgDung == UserId);
            return View(hocSinh);
        }

        public IActionResult ThemHS(string UserId)
        {
            NguoiDung nguoidung = new NguoiDung();
            var itemLast = _applicationDbContext.NguoiDungs.Where(x=> !x.isGV).LastOrDefault();
            nguoidung.MaNgDung = AutomaticID(itemLast.MaNgDung,2);
            return View(nguoidung);
        }

        [HttpPost]
        public IActionResult ThemHocSinh(NguoiDung hocSinh)
        {
            var addHS = _applicationDbContext.NguoiDungs.Add(hocSinh);
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

        public IActionResult DiemSo(string UserId)
        {
            UserId = "00003";
            if (UserId == null)
            {
                return NotFound();
            }
            //var user = _applicationDbContext.AppUsers.Include(m => m.LoaiDiems).Where(i => i.Id == "123");
            return View("DiemSo");
        }
    }
}
