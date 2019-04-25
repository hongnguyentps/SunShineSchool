using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class Lop
    {
        public string Id { get; set; }

        public string TenLop { get; set; }

        public string GVCNId { get; set; }

        public NguoiDung GVCN { get; set; }

        public string KhoiId { get; set; }

        public Khoi Khoi { get; set; }

        public string NienKhoaId { get; set; }

        public NienKhoa NienKhoa { get; set; }

        public string Ghichu { get; set; }

        public ICollection<LopHS> LopHss { get; set; }

        public ICollection<LopGV> LopGVs { get; set; }

        public ICollection<KetQua> KetQuas { get; set; }

        public ICollection<Diem> Diems { get; set; }
    }
}
