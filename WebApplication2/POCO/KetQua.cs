using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class KetQua
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public NguoiDung User { get; set; }

        public string LopId { get; set; }

        public Lop Lop { get; set; }

        public double diemTBCN { get; set; }

        public string HocLucId { get; set; }

        public HocLuc HocLuc { get; set; }

        public string HanhKiemId { get; set; }

        public HanhKiem HanhKiem { get; set; }

        public string GhiChu { get; set; }
    }
}
