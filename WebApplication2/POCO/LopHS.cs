using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class LopHS
    {
        public string LopId { get; set; }
        public Lop Lop { get; set; }

        public string UserId { get; set; }
        public NguoiDung User { get; set; }

        public string GhiChu { get; set; }

    }
}
