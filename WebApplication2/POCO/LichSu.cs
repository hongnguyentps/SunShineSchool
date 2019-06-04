using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class LichSu
    {
        public int Id { get; set; }

        public int DiemId { get; set; }

        public string UserId { get; set; }

        public string LopId { get; set; }

        public string MaMH { get; set; }

        public string MaHKy { get; set; }

        public string LoaiDiemId { get; set; }

        public double? DiemTruoc { get; set; }

        public double? DiemSau { get; set; }

        public DateTime ThoiGian { get; set; }

        public string LyDo { get; set; }
    }
}
