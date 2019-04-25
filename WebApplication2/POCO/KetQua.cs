using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.POCO
{
    public class KetQua
    {
        public int Id { get; set; }

        public NguoiDung MaHS { get; set; }

        public Lop Lop { get; set; }

        public HocLuc HocLuc { get; set; }

        public HanhKiem HanhKiem { get; set; }

    }
}
