using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.POCO;

namespace WebApplication2.Models
{
    public class LopViewModel
    {
        public string LopId { get; set; }

        public string TenLop { get; set; }

        public string TenGVCN { get; set; }

        public string NienKhoa { get; set; }
    }

    public class HienThiLop
    {
        public List<Khoi> Khois { get; set; }

        public List<NienKhoa> NienKhoas { get; set; }

        public List<LopViewModel> LopViewModel { get; set; }
    }
}
