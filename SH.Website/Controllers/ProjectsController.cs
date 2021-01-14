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

namespace SH.Website.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IFactory _factory;
  

        public ProjectsController(IApplicationDbContext context, IFactory factory)
        {
            _context = context;
            _factory = factory;
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

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("projectName,projectDescription,status,clientCompany,projectLeader,estimatedBudget,totalAmountSpent,estimatedProjectDuration ")] ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.FromSqlInterpolated($" exec dbo.spUpdateProjectByName ('{viewModel.projectName}', '{viewModel.projectDescription}', '{viewModel.status}','{viewModel.clientCompany}', '{ viewModel.projectLeader}',' {viewModel.estimatedBudget}', '{viewModel.totalAmountSpent}','{viewModel.estimatedProjectDuration}')");            
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Dashboard", "Home");
        }*/





        public async Task<IActionResult> Edit(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.projectName == name);
            if (project == null)
            {
                return NotFound();
            }
            PopulateProjectsDropDownList(project.projectName);
            return View(project);
        }

        private void PopulateProjectsDropDownList(object selectedProject = null)
        {
            var projectsQuery = from p in _context.Projects
                                   orderby p.projectName
                                   select p;
            ViewBag.projectName = new SelectList(projectsQuery.AsNoTracking(), "projectName", "projectName", selectedProject);
        }
        public IActionResult Create()
        {
            PopulateProjectsDropDownList();
            return View();
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var projectToUpdate = await _context.Projects
                .FirstOrDefaultAsync(c => c.projectName == name);

            if (await TryUpdateModelAsync<ProjectModel>(projectToUpdate,
                "",
                c => c.projectName, c => c.projectDescription, c => c.status, c => c.clientCompany, c => c.projectLeader, c => c.estimatedBudget, c => c.totalAmountSpent, c => c.estimatedProjectDuration))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Dashboard", "Home");
            }
            PopulateProjectsDropDownList(projectToUpdate.projectName);
            return RedirectToAction("Dashboard", "Home");
        }

    }
}
