using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public AdminContactsController(IApplicationDbContext context, IFactory factory)
        {
            _factory = factory;
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("to,Subject,Message,Attachment")] AdminContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (await _factory.PostAdminContactViewModel(viewModel))
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
        
    }
}
