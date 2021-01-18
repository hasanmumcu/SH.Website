using SH.Website.Models;
using System.Collections.Generic;
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
        Task<AnalystContactModel> PostAnalystContact(AnalystContactModel model);
        Task<UserContactModel> PostUserContact(UserContactModel model);
        Task<ProjectModel> PostProject(ProjectModel model);
        void UpdateProject(ProjectModel model);
        public ProjectModel GetProjectData();
        public void Initial(RegisterModel model);
        public List<AnalystContactModel> AdminMailBox();
        public List<AdminContactModel> AnalystMailBox();
        public List<string> GetRegistersData();
        public List<AnalystContactModel> UserMailBox();
    }
}