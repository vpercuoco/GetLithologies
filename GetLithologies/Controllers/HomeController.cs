using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetLithologies.Models;
using Microsoft.EntityFrameworkCore;

namespace GetLithologies.Controllers
{
    [Route("[controller]/[action]")]
    [Controller]
    public class HomeController : Controller
    {
        private readonly IDataRepository _repo;

        public HomeController(IDataRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
     
            return View();
        }
        public IActionResult APIView()
        {
     
            return View();
        }
        public IActionResult ChartView()
        {

            return View();

            
        }
    }
}
