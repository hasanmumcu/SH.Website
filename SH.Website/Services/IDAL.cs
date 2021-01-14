using SH.Website.Models;
using System.Threading.Tasks;

namespace SH.Website.Services
{
    public interface IDAL
    {
        Task<IndexModel> GetIndexModel();
        Task<ContactModel> PostContact(ContactModel model);
        Task<LoginModel> PostLogin(LoginModel model);
        Task<RegisterModel> PostRegister(RegisterModel model);
        Task<AdminContactModel> PostAdminContact(AdminContactModel model);
        Task<ProjectModel> PostProject(ProjectModel model);
    }
}