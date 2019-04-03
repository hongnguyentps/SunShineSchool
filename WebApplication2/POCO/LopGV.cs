using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class LopGV
    {
        public string UserId { get; set; }
        public int LopId { get; set; }
        public Lop Lop { get; set; }
        public ApplicationUser User { get; set; }
    }
}
