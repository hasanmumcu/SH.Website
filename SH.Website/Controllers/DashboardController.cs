
using Microsoft.AspNetCore.Mvc;
using SH.Website.Authentication;

namespace SH.Website.Controllers
{
    [UnAuthorized]
    public class DashboardController : Controller
    {
        [Authorize(Roles.DIRECTOR)]
        public IActionResult DirectorPage()
        {
            return View("DirectorPage");
        }

        [Authorize(Roles.USER)]
        public IActionResult SupervisorPage()
        {
            ViewBag.Message = "Permission controlled through action Attribute";
            return View("UserPage");
        }

        [Authorize(Roles.ANALYST)]
        public IActionResult AnalystPage()
        {
            return View("AnalystPage");
        }

        public IActionResult NoPermission()
        {
            return View();
        }

        public IActionResult SupervisorAnalystPage()
        {
            ViewBag.Message = "Permission controlled inside action method";
            if (this.HavePermission(Roles.USER))
                return View("SupervisorPage");

            if (this.HavePermission(Roles.ANALYST))
                return View("AnalystPage");

            return new RedirectResult("~/Dashboard/NoPermission");
        }
        //This action method is in Dashboard.cs
        public JsonResult AuthenticateAjaxCalls()
        {
            return Json(new { result = "success" });
        }

        [Authorize(Roles.DIRECTOR, Roles.USER)]
        public JsonResult AuthorizeAjaxCalls()
        {
            return Json(new { result = "success" });
        }

        //This action method is in HomeController.cs 
        public JsonResult EndSession()
        {
            HttpContext.Session.Clear();
            return Json(new { result = "success" });
        }

    }
}
