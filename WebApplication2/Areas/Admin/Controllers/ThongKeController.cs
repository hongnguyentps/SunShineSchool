using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Areas
{
    [Area("admin")]
    public class ThongKeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public ThongKeController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
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
            var kqs = _applicationDbContext.KetQuas.Where(x =>
                (khoi == "0" || x.Lop.KhoiId == khoi) && (nienkhoa == "0" || x.Lop.NienKhoaId == nienkhoa)).ToList();
            var xeploais = kqs.Select(x => new
            {
                Xeploai = XepLoai(x.diemTBCN)
            });

            var returnData = xeploais.GroupBy(m => m.Xeploai).Select(m => new
            {
                Key = m.Key,
                Count = m.Count()
            });

            BaoCaoThongKe BaoCaoThongKe = new BaoCaoThongKe
            {
                SLHSGioi = returnData.FirstOrDefault(k => k.Key == "A")?.Count ?? 0,
                SLHSKha = returnData.FirstOrDefault(k => k.Key == "B")?.Count ?? 0,
                SLHSTB = returnData.FirstOrDefault(k => k.Key == "C")?.Count ?? 0,
                SLHSYeu = returnData.FirstOrDefault(k => k.Key == "D")?.Count ?? 0,
            };

            return View(BaoCaoThongKe);
        }

        private string XepLoai(double diemTb)
        {
            var hocluc = _applicationDbContext.HocLucs.ToList();
            if (diemTb >= 8) return "A";
            if (diemTb >= 6.5 && diemTb < 8) return "B";
            if (diemTb < 6.5 && diemTb >= 5) return "C";
            if (diemTb < 5) return "D";
            return string.Empty;
        }
    }

    public class BaoCaoThongKe
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SLHSGioi { get; set; }
        public int SLHSKha { get; set; }
        public int SLHSTB { get; set; }
        public int SLHSYeu { get; set; }
    }

}