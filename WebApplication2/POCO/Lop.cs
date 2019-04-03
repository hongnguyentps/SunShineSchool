using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; }
        public string NienKhoa { get; set; }
        public string Ghichu { get; set; }

        public ICollection<LopGV> LopGvs { get; set; }
    }
}
