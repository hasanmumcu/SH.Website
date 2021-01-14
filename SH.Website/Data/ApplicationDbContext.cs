using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SH.Website.Authentication;
using SH.Website.Models;



namespace SH.Website.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public Microsoft.EntityFrameworkCore.DbSet<PartialModel> Partials { get; set; } 
        public Microsoft.EntityFrameworkCore.DbSet<IndexModel> Index { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ContactModel> Contacts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<LoginModel> Logins { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<RegisterModel> Registers { get; set; }
        
        public Microsoft.EntityFrameworkCore.DbSet<AdminContactModel> AdminContacts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ProjectModel> Projects { get; set; }



    }
}
