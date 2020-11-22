using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SH.Website.Models;


namespace SH.Website.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public DbSet<PartialModel> Partials { get; set; } 
        public DbSet<IndexModel> Index { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<RegisterModel> Registers { get; set; }


    }
}
