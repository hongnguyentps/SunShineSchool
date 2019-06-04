using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.POCO;

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

        public async Task<IActionResult> Index(string khoi = "0", string nienkhoa = "0" , string lop = "0")
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            // Get the roles for the user
            var isAdmin = await _userManager.GetRolesAsync(user);
            ViewBag.Role = isAdmin[0];
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

            var dsLop = GetLop(khoi, nienkhoa);
            var allLop = new List<SelectListItem>
            {
                new SelectListItem {Text = "All", Value = "0"}
            };
            allLop.AddRange(new SelectList(dsLop, "Id", "TenLop"));
            ViewBag.AllLop = allLop;

            var kqs = _applicationDbContext.KetQuas.Where(x =>
                (khoi == "0" || x.Lop.KhoiId == khoi) && (nienkhoa == "0" || x.Lop.NienKhoaId == nienkhoa) && (lop == "0" || x.Lop.Id == lop)).ToList();
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

        public List<Lop> GetLop(string makhoi, string nienkhoa)
        {
            var lop = _applicationDbContext.Lops.Where(i=> (makhoi == "0" || i.KhoiId == makhoi) && (nienkhoa == "0" || i.NienKhoaId == nienkhoa)).ToList();
            return lop;
        }

        public JsonResult GetLopJson(string makhoi, string nienkhoa)
        {
            var lop = GetLop(makhoi, nienkhoa);
            return new JsonResult(lop);
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