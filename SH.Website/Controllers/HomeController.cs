using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SH.Website.Authentication;
using SH.Website.Models;
using SH.Website.Services;
using System.Security.Principal;
using System.Data.SqlClient;
using System.Collections.Generic;
using SH.Website.Models.ViewModels;
using System.Linq;
using System;
using System.Data;
using SH.Website.Data;
using Microsoft.EntityFrameworkCore;

namespace SH.Website.Controllers
{
    //[Authorize(Roles.DIRECTOR, Roles.USER, Roles.ANALYST)]
    public class HomeController : Controller
    {
        protected IFactory _factory;
        private readonly ILogger<HomeController> _logger;
        private readonly System.Collections.Generic.List<AdminContactModel> AdminContactList = new System.Collections.Generic.List<AdminContactModel>();
        private readonly System.Collections.Generic.List<ProjectModel> ProjectList = new System.Collections.Generic.List<ProjectModel>();
        protected IApplicationDbContext _context;

        

        public HomeController(ILogger<HomeController> logger, IFactory factory, IApplicationDbContext context)
        {
            _logger = logger;
            _factory = factory;
            _context = context;
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
        public IActionResult ProjectAdd()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProjectEdit()
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
        public IActionResult Compose()
        {
            return View();
        }

        public IActionResult MailBox()
        {

            using (var connection = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.AdminContacts;",
                  connection);
                connection.Open();
                

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        AdminContactModel adminContactModel = new AdminContactModel

                        {

                            Id = reader.GetGuid(0),
                            to = reader.GetString(1),
                            Subject = reader.GetString(2),
                            Message = reader.GetString(3),
                            Attachment = reader.GetString(4),
                            Active = reader.GetBoolean(5),
                            Timestamp = reader.GetDateTime(6)


                        };
                        AdminContactList.Add(adminContactModel);
                        //ViewData["Message"] = adminContactModel;
                        ViewBag.Message = AdminContactList;

                        
                    }
                    return View();
                }
                else
                {
                    //  
                }
                reader.Close();

            }

            return View();

        }
        public IActionResult ReadMail()
        {

            using (var connection = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.AdminContacts;",
                  connection);
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        AdminContactModel adminContactModel = new AdminContactModel

                        {

                            Id = reader.GetGuid(0),
                            to = reader.GetString(1),
                            Subject = reader.GetString(2),
                            Message = reader.GetString(3),
                            Attachment = reader.GetString(4),
                            Active = reader.GetBoolean(5),
                            Timestamp = reader.GetDateTime(6)


                        };
                        AdminContactList.Add(adminContactModel);
                        //ViewData["Message"] = adminContactModel;
                        ViewBag.Message = AdminContactList;


                    }
                    return View();
                }
                else
                {
                    //  
                }
                reader.Close();

            }

            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
