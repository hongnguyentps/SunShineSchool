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

        public string HsId { get; set; }

        public string NoiDungViPham { get; set; }

        public string MaHK { get; set; }

        public DateTime NgayViPham { get; set; }

        public string GhiChu { get; set; }

        public NguoiDung Hs { get; set; }
    }
}
