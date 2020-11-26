using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SH.Website.Authentication;
using SH.Website.Models;
using SH.Website.Services;
using System.Security.Principal;

namespace SH.Website.Controllers
{
    //[Authorize(Roles.DIRECTOR, Roles.USER, Roles.ANALYST)]
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

        //public IActionResult Login()
        //{
        //    return View();
        //}
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult LoginUser(User user)
        {

            TokenProvider _tokenProvider = new TokenProvider();
            //Authenticate user
            var userToken = _tokenProvider.LoginUser(user.Email.Trim(), user.Password.Trim());
            if (userToken != null)
            {
                //Save token in session object
                HttpContext.Session.SetString("JWToken", userToken);
            }
            return Redirect("~/Home/Login");
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult User()
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
