using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class HocKy
    {
        public string MaHKy { get; set; }

        public string TenHKy { get; set; }

        public ICollection<Diem> Diems { get; set; }
    }
}
