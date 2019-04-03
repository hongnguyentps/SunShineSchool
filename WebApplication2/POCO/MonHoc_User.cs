using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class MonHoc_User
    {
        public string UserId { get; set; }
        public int IdMH { get; set; }
        public Subject Subject { get; set; }
        public ApplicationUser User { get; set; }
    }
}
