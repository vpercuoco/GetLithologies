using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetLithologies.Models;

namespace GetLithologies.Controllers
{
    [Route("[controller]/[action]")]
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var x = new HierarchyLookupStateModel();
            return View();
        }
        public IActionResult APIView()
        {
            var x = new HierarchyLookupStateModel();
            return View();
        }
    }
}
