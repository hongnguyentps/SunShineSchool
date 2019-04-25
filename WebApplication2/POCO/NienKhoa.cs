using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class NienKhoa
    {
        public string NienKhoaId { get; set; }
        public string TenNK { get; set; }

        public ICollection<Lop> Lops { get; set; }
    }
}
