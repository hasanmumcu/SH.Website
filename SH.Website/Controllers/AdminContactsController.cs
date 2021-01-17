using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SH.Website.Data;
using SH.Website.Models;
using SH.Website.Models.ViewModels;
using SH.Website.Services;

namespace SH.Website.Controllers
{
    [Authorize]
    public class AdminContactsController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IFactory _factory;
        private readonly List<AdminContactModel> AdminContactList;
        private readonly  IWebHostEnvironment _hostingEnvironment;

        public AdminContactsController(IApplicationDbContext context, IFactory factory, IWebHostEnvironment environment)
        {
            _factory = factory;
            _hostingEnvironment = environment;
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("to,Subject,Message") ] AdminContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (await _factory.PostAdminContactViewModel(viewModel) )
                {
                    return RedirectToAction("Dashboard", "Home");
                }

            }
            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult MailBox() {

            using (var connection = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.AnalystContacts;",
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
                             Active = reader.GetBoolean(4),
                             Timestamp = reader.GetDateTime(5)


                        };
                        AdminContactList.Add(adminContactModel);
                        ViewData["Message"] = adminContactModel;
                        return View();
                    }
                }
                else
                {
                    //
                }
                reader.Close();
                
            }
   
            return View();

        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult deletefile(string fname)
        {
            string _imageToBeDeleted = Path.Combine(_hostingEnvironment.WebRootPath, "img\\", fname);
            if ((System.IO.File.Exists(_imageToBeDeleted)))
            {
                System.IO.File.Delete(_imageToBeDeleted);
            }
            return RedirectToAction("index", new { deleted = fname });
        }

       
    }
}
