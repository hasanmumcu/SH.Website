using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SH.Website.Data;
using SH.Website.Models;
using SH.Website.Models.ViewModels;
using SH.Website.Services;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace SH.Website.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IFactory _factory;
        private readonly IDAL _dal;

        public ProjectsController(IApplicationDbContext context, IFactory factory, IDAL dal)
        {
            _context = context;
            _factory = factory;
            _dal = dal;
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("projectName,projectDescription,status,clientCompany,projectLeader,estimatedBudget,totalAmountSpent,estimatedProjectDuration ")] ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (await _factory.PostProjectViewModel(viewModel))
                {

                    return RedirectToAction("Dashboard", "Home");
                    
                }

            }

            return RedirectToAction("Dashboard", "Home");
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_project([Bind] ProjectModel project)
        {

            if (ModelState.IsValid)
            {
                _dal.UpdateProject(project);
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Dashboard", "Home");
        }


        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
