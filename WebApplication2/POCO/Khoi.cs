using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class Khoi
    {
        public string Id { get; set; }

        public string TenKhoi { get; set; }

        public ICollection<Lop> Lops { get; set; }
    }
}
