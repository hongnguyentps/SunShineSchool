using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using WebApplication2.Data;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class GiaoVienController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GiaoVienController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IActionResult> Index(string SearchString, int page = 1)
        {
            var giaovien = from s in _applicationDbContext.NguoiDungs where(s.isGV &&
                                                                           (string.IsNullOrEmpty(SearchString) ||
                                                                           (s.Ho.Contains(SearchString) || s.Ten.Contains(SearchString))))
                select s;
            
            int pageSize = 10;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var model = await PagingList.CreateAsync(giaovien.OrderBy(x => x.MaNgDung), pageSize, page);
            model.RouteValue = new RouteValueDictionary {
                { "SearchString", SearchString}
            };
            return View("GiaoVien", model);
        }
    }
}