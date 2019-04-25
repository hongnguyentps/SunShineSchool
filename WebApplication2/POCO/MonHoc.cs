using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class MonHoc
    {
        public string MaMH { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }
        public string MoTa { get; set; }

        public ICollection<Diem> Diems { get; set; }
    }
}
