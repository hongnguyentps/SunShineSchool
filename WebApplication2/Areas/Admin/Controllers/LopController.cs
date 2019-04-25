using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.POCO;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LopController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LopController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(string khoi = "0", string nienkhoa = "0")
        {
            var data = _applicationDbContext;

            var listKhoi = data.Khois.OrderBy(x => x.Id).ToList();
            var allkhoi = new List<SelectListItem>
            {
                new SelectListItem {Text = "All", Value = "0"}
            };
            allkhoi.AddRange(new SelectList(listKhoi, "Id", "TenKhoi"));
            ViewBag.AllKhoi = allkhoi;

            var listNK = data.NienKhoas.OrderBy(y => y.NienKhoaId).ToList();
            var allNienKhoa = new List<SelectListItem>
            {
                new SelectListItem {Text = "All", Value = "0"}
            };
            allNienKhoa.AddRange(new SelectList(listNK, "NienKhoaId", "TenNK"));
            ViewBag.AllNK = allNienKhoa;

            var ShowAllLop = data.Lops.Where(x => (khoi == "0" || x.KhoiId == khoi) && (nienkhoa == "0" || x.NienKhoaId == nienkhoa))
             .Select(x => new Models.LopViewModel
             {
                 LopId = x.Id,
                 TenLop = x.TenLop,
                 TenGiaoVien = x.GVCN.Ten,
                 NienKhoa = x.NienKhoa.TenNK,
             }).ToList();
            return View(ShowAllLop);
        }

        public IActionResult XemDSTheoLop(string id)
        {
            var data = _applicationDbContext.LopHss.Include(x=> x.User).Include(x=> x.Lop).Where(x => id == x.LopId).ToList();
            return View(data);
        }

    }
}