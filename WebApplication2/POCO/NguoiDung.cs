using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class NguoiDung
    {
        public string MaNgDung { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public bool isGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public int Cmnd { get; set; }
        public int SDT { get; set; }
        public string Email { get; set; }
        public string HinhThe { get; set; }
        public string HoTenCha { get; set; }
        public string HoTenMe { get; set; }
        public string GhiChu { get; set; }
        [NotMapped]
        public string MonHoc { get; set; }

        [NotMapped]
        public string MaLop { get; set; }

        public ApplicationUser Account { get; set; }
        public ICollection<Diem> DiemIds { get; set; }
        public ICollection<Lop> Lops { get; set; }
        public ICollection<LopGV> LopGvs { get; set; }
        public ICollection<LopHS> LopHss { get; set; }
        public ICollection<ViPham> ViPhams { get; set; }
        public ICollection<KetQua> KetQuas { get; set; }
        public ICollection<YKienPH> YKien { get; set; }
        public ICollection<SuKien> SuKiens { get; set; }
    }
}
