using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin
{
    [Area("admin")]
    public class StudentManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
