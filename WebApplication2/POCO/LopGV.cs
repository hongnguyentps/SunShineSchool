using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class LopGV
    {
        public int Id { get; set; }
        
        public string LopId { get; set; }

        public Lop Lop { get; set; }

        public string MonHocId { get; set; }

        public MonHoc MonHoc { get; set; }

        public string GVBMId { get; set; }

        public NguoiDung GVBM { get; set; }

        public string GhiChu { get; set; }
    }
}
