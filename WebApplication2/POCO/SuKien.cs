using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class SuKien
    {
        public int SuKienId { get; set; }

        public string LoaiSK { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public string NguoiTao { get; set; }

        public DateTime NgayTao { get; set; }

        public string GhiChu { get; set; }
    }
}
