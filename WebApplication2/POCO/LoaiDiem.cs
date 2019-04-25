using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class LoaiDiem
    {
        public string Id { get; set; }

        public string TenLoai { get; set; }

        public string HeSo { get; set; }

        public ICollection<Diem> Diems { get; set; }
    }
}
