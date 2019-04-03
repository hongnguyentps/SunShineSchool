using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class Diem 
    {

        public int DiemId { get; set; }

        public double DiemSo { get; set; }

        public int IdMH { get; set; }
        
        public string UserId { get; set; }

        public int IdHeSo { get; set; }

        public string GhiChu { get; set; }

        public ApplicationUser User { get; set; } 
    }
}
