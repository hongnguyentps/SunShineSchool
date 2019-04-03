using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class ViPham
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TenLoi { get; set; }
        public string TenDiem { get; set; }
        public string GhiChu { get; set; }

        public ApplicationUser User { get; set; }
    }
}
