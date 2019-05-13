using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class Diem
    {
        public int DiemId { get; set; }

        public string UserId { get; set; }
        public NguoiDung User { get; set; }

        public string LopId { get; set; }
        public Lop Lop { get; set; }

        public string MonHocMaMH { get; set; }
        public MonHoc MonHoc { get; set; }

        public string HocKyMaHKy { get; set; }
        public HocKy HocKy { get; set; }

        public string LoaiDiemId { get; set; }
        public LoaiDiem LoaiDiem { get; set; }

        public double DiemSo { get; set; }

        public string GhiChu { get; set; }
    }
}
