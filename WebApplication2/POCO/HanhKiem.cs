using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class HanhKiem
    {
        public string MaHK { get; set; }

        public string TenHK { get; set; }

        public ICollection<KetQua> KetQuas { get; set; }
    }
}
