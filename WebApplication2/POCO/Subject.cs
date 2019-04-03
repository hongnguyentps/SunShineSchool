using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.POCO
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        public ICollection<MonHoc_User> MonHocUsers { get; set; }
    }
}
