using Microsoft.EntityFrameworkCore;
using SH.Website.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SH.Website.Data
{
    public interface IApplicationDbContext
    {
        DbSet<IndexModel> Index { get; set; }
        DbSet<PartialModel> Partials { get; set; }
        DbSet<ContactModel> Contacts { get; set; }
        DbSet<LoginModel> Logins { get; set; }
        DbSet<RegisterModel> Registers { get; set; }
        DbSet<AdminContactModel> AdminContacts { get; set; }
        DbSet<ProjectModel> Projects { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
      

    }
}