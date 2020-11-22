using SH.Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
using SH.Website.Models;
using SH.Website.Models.ViewModels;
using Microsoft.VisualBasic;

namespace SH.Website.Services
{
    public class DAL : IDAL
    {
        protected IApplicationDbContext _context;
        public DAL(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.IndexModel> GetIndexModel()
        {
            return await _context.Index.Include(s => s.Partials).FirstOrDefaultAsync(s => s.Active);

        }
        public async Task<ContactModel> PostContact(ContactModel model)
        {
            await _context.Contacts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model; 
        }
        public async Task<LoginModel> PostLogin(LoginModel model)
        {
            await _context.Logins.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<RegisterModel> PostRegister(RegisterModel model)
        {
            await _context.Registers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

    }
}
