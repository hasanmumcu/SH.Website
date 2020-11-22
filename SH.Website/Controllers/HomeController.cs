using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SH.Website.Data;
using SH.Website.Models;
using SH.Website.Services;

namespace SH.Website.Controllers
{

    public class HomeController : Controller
    {
        protected IFactory _factory;
        private readonly ILogger<HomeController> _logger;
     

        public HomeController(ILogger<HomeController> logger, IFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _factory.GetIndexViewModel());
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
