using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class YKienPH
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public NguoiDung User { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayTao { get; set; }

        public string GhiChu { get; set; }
    }
}
