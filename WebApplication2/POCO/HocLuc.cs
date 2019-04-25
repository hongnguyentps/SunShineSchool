using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class HocLuc
    {
        public string MaHL { get; set; }

        public string TenHL { get; set; }

        public string DiemCanDuoi { get; set; }

        public string DiemCanTren { get; set; }

        public string DiemKhongChe { get; set; }

        public ICollection<KetQua> KetQuas { get; set; }
    }
}
