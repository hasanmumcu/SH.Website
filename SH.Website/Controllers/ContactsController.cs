using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SH.Website.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IFactory _factory;

        public ContactsController(IApplicationDbContext context, IFactory factory)
        {
            _factory = factory;
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("Name,Email,Subject,Message")] ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (await _factory.PostContactViewModel(viewModel))
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return RedirectToAction("Index", "Home");
        }


    }
}
