using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.POCO;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LopController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public LopController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string khoi = "0", string nienkhoa = "0")
        {
            //Check user role
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var role = await _userManager.GetRolesAsync(user);
            ViewBag.role = role[0];
            if (!User.Identity.IsAuthenticated || role[0] == "Học Sinh")
            {
                return Redirect("https://localhost:44374");
            }

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

            var UserCurrently = _userManager.GetUserAsync(User);
            var isAdmin = role[0] == "Admin";

            var ShowAllLop = data.Lops.Join(data.LopGvs, lop => lop.Id, lopgv => lopgv.LopId, (lop, lopgv) => new { Lop = lop, LopGv = lopgv })
                    .Where(x =>
                        (khoi == "0" || x.Lop.KhoiId == khoi) && (nienkhoa == "0" || x.Lop.NienKhoaId == nienkhoa) &&
                        (isAdmin || x.LopGv.GVBMId == UserCurrently.Result.NguoiDungId)
                    )
             .Select(x => new Models.LopViewModel
             {
                 LopId = x.Lop.Id,
                 TenLop = x.Lop.TenLop,
                 TenGVCN = x.Lop.GVCN.Ten,
                 NienKhoa = x.Lop.NienKhoa.TenNK,
             }).Distinct().OrderBy(x => x.NienKhoa).ToList();
            return View(ShowAllLop);
        }

        public IActionResult XemDSTheoLop(string id)
        {
            var data = _applicationDbContext.LopHss.Include(x => x.User).Include(x => x.Lop).Where(x => id == x.LopId).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult NhapDiem(string lopId)
        {
            var data = _applicationDbContext.LopHss
                .Include(x => x.User)
                .Include(x => x.Lop)
                .Where(x => lopId == x.LopId)
                .ToList();
            var UserCurrently = _userManager.GetUserAsync(User);
            var monHocId = _applicationDbContext.LopGvs
                .FirstOrDefault(x => x.GVBMId == UserCurrently.Result.NguoiDungId && x.LopId == lopId)?.MonHocId;
            string hocKy = string.Empty;
            if (DateTime.Now.Month >= 1 || DateTime.Now.Month <= 6)
            {
                hocKy = "HK1";
            }
            else
            {
                hocKy = "HK2";
            }

            var list = new List<DiemCaNhan>();
            foreach (var item in data)
            {
                DiemCaNhan diemCaNhan = new DiemCaNhan();
                diemCaNhan.MaNgDung = item.User.MaNgDung;
                diemCaNhan.Ho = item.User.Ho;
                diemCaNhan.Ten = item.User.Ten;
                diemCaNhan.GioiTinh = item.User.GioiTinh;
                diemCaNhan.NgaySinh = item.User.NgaySinh;

                var DiemMiengs = _applicationDbContext.Diems.Where(x =>
                    x.LopId == lopId && x.LoaiDiemId == "LD0001" && x.MonHocMaMH == monHocId && x.HocKyMaHKy == hocKy && x.UserId == item.User.MaNgDung).Select(x => new { x.DiemSo, x.DiemId });
                diemCaNhan.DiemMiengs = DiemMiengs.Select(m => new DiemDetail()
                {
                    Diem = m.DiemSo,
                    DiemId = m.DiemId
                }).ToList();

                var Diem15ps = _applicationDbContext.Diems.Where(x =>
                    x.LopId == lopId && x.LoaiDiemId == "LD0002" && x.MonHocMaMH == monHocId && x.HocKyMaHKy == hocKy && x.UserId == item.User.MaNgDung).Select(x => new { x.DiemSo, x.DiemId });
                diemCaNhan.Diem15ps = Diem15ps.Select(m => new DiemDetail()
                {
                    Diem = m.DiemSo,
                    DiemId = m.DiemId
                }).ToList();

                var Diem1Tiets = _applicationDbContext.Diems.Where(x =>
                    x.LopId == lopId && x.LoaiDiemId == "LD0003" && x.MonHocMaMH == monHocId && x.HocKyMaHKy == hocKy && x.UserId == item.User.MaNgDung).Select(x => new { x.DiemSo, x.DiemId });
                diemCaNhan.Diem1Tiets = Diem1Tiets.Select(m => new DiemDetail()
                {
                    Diem = m.DiemSo,
                    DiemId = m.DiemId
                }).ToList();

                var DiemGiuaKys = _applicationDbContext.Diems.Where(x =>
                    x.LopId == lopId && x.LoaiDiemId == "LD0004" && x.MonHocMaMH == monHocId && x.HocKyMaHKy == hocKy && x.UserId == item.User.MaNgDung).Select(x => new { x.DiemSo, x.DiemId });
                diemCaNhan.DiemGiuaKys = DiemGiuaKys.Select(m => new DiemDetail()
                {
                    Diem = m.DiemSo,
                    DiemId = m.DiemId
                }).ToList();

                var DiemCuoiKys = _applicationDbContext.Diems.Where(x =>
                    x.LopId == lopId && x.LoaiDiemId == "LD0005" && x.MonHocMaMH == monHocId && x.HocKyMaHKy == hocKy && x.UserId == item.User.MaNgDung).Select(x => new { x.DiemSo, x.DiemId });
                diemCaNhan.DiemCuoiKys = DiemCuoiKys.Select(m => new DiemDetail()
                {
                    Diem = m.DiemSo,
                    DiemId = m.DiemId
                }).ToList();
                list.Add(diemCaNhan);
            }

            var dto = new LayDanhSachLopForDiemDto()
            {
                DiemCaNhans = list,
                GVBMId = UserCurrently.Result.NguoiDungId,
                MonHocId = monHocId,
                LopId = lopId
            };
            return View(dto);
        }

        [HttpPost]
        public ActionResult LuuDiem(DiemDTO dto)
        {
            Diem diem = new Diem
            {
                DiemSo = dto.DiemSo,
                UserId = dto.UserId,
                LopId = dto.LopId,
                MonHocMaMH = dto.MonHocMaMH,
                HocKyMaHKy = dto.HocKyMaHKy,
                LoaiDiemId = dto.LoaiDiemId
            };
            if (dto.DiemId == 0)
            {
                _applicationDbContext.Diems.Add(diem);
            }
            else if (dto.DiemId != 0)
            {
                var diemDb = _applicationDbContext.Diems.FirstOrDefault(i => i.DiemId == dto.DiemId);
                if (diemDb != null)
                {
                    if (dto.DiemSo > 0)
                    {
                        diemDb.DiemSo = dto.DiemSo;
                        _applicationDbContext.Diems.Update(diemDb);
                    }
                    else
                    {
                        _applicationDbContext.Diems.Remove(diemDb);
                    }
                }
            }
            _applicationDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult TinhDTB(string lopId)
        {
            var hocsinhs = _applicationDbContext.NguoiDungs
                .Where(m => m.LopHss.FirstOrDefault(k => k.LopId == lopId) != null).Select(m => m.MaNgDung).ToList();

            var diemHosSinh = _applicationDbContext.Diems
                .Include(x => x.HocKy)
                .Include(x => x.User)
                .Include(x => x.MonHoc)
                .Include(x => x.LoaiDiem)
                .Where(x => hocsinhs.Contains(x.UserId)).GroupBy(x => new { x.User, x.MonHoc }).Select(m =>
                       new DiemViewModel2()
                       {
                           User = m.Key.User,
                           MaMH = m.Key.MonHoc.MaMH,
                           TenMH = m.Key.MonHoc.TenMonHoc,
                           DiemDetailViewModels = m.Select(x => new DiemDetailViewModel2()
                           {
                               Diem = x.DiemSo,
                               Heso = x.LoaiDiem.HeSo,
                               LoaiDiem = x.LoaiDiemId
                           }).ToList()
                       }).ToList().GroupBy(m => m.User).Select(m => new
                       {
                           User = m.Key,
                           Diems = m.ToList()
                       });


            foreach (var hocsinh in diemHosSinh)
            {
                foreach (var data in hocsinh.Diems)
                {
                    var tongDiem = data.DiemDetailViewModels.Sum(m => m.Diem * int.Parse(m.Heso));
                    var tongHeso = data.DiemDetailViewModels.Sum(m => int.Parse(m.Heso));
                    data.DiemTb = tongDiem / tongHeso;
                    data.Xeploai = GetXepLoai(data);
                }
                var diemTBHocKy = GetDiemTBCN(hocsinh.Diems);
                var xepLoaiHocKy = XepLoai(GetDiemTBCN(hocsinh.Diems));
                var diemTBmon = new KetQua()
                {
                    UserId = hocsinh.User.MaNgDung,
                    diemTBCN = diemTBHocKy,
                    HocLucId = xepLoaiHocKy,
                    HanhKiemId = null,
                    LopId = lopId
                };

                var deletedKQ = _applicationDbContext.KetQuas.FirstOrDefault(i => i.UserId == hocsinh.User.MaNgDung && i.LopId == lopId);
                if (deletedKQ != null)
                {
                    _applicationDbContext.KetQuas.Remove(deletedKQ);
                }

                _applicationDbContext.KetQuas.Add(diemTBmon);
            }

            _applicationDbContext.SaveChanges();
            return Ok();
        }
        public class DiemViewModel2
        {
            public DiemViewModel2()
            {
                DiemDetailViewModels = new List<DiemDetailViewModel2>();
            }
            public string MaMH { get; set; }
            public string TenMH { get; set; }
            public double DiemTb { get; set; }
            public string Xeploai { get; set; }
            public NguoiDung User { get; set; }
            public List<DiemDetailViewModel2> DiemDetailViewModels { get; set; }
        }

        public class DiemDetailViewModel2
        {
            public double Diem { get; set; }
            public string Heso { get; set; }
            public string LoaiDiem { get; set; }
        }

        private string GetXepLoai(DiemViewModel2 diemViewModel)
        {
            return XepLoai(diemViewModel.DiemTb);
        }

        private string XepLoai(double diemTb)
        {
            var hocluc = _applicationDbContext.HocLucs.ToList();
            if (diemTb >= 8) return "HL0001";
            if (diemTb >= 6.5 && diemTb < 8) return "HL0002";
            if (diemTb < 6.5 && diemTb >= 5) return "HL0003";
            if (diemTb < 5) return "HL0004";
            return string.Empty;
        }

        public double GetDiemTBCN(List<DiemViewModel2> diemViewModel)
        {
            return diemViewModel.Sum(m => m.DiemTb) / diemViewModel.Count;
        }
    }
}