using SH.Website.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SH.Website.Models;
using System.Data.SqlClient;
using System.Data;

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
        public async Task<AdminContactModel> PostAdminContact(AdminContactModel model)
        {
            await _context.AdminContacts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<ProjectModel> PostProject(ProjectModel model)
        {
            await _context.Projects.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public void UpdateProject(ProjectModel model)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@projectDescription", model.projectDescription);
                cmd.Parameters.AddWithValue("@status", model.status);
                cmd.Parameters.AddWithValue("@clientCompany", model.clientCompany);
                cmd.Parameters.AddWithValue("@projectLeader", model.projectLeader);
                cmd.Parameters.AddWithValue("@estimatedBudget", model.estimatedBudget);
                cmd.Parameters.AddWithValue("@totalAmountSpent", model.totalAmountSpent);
                cmd.Parameters.AddWithValue("@estimatedProjectDuration", model.estimatedProjectDuration);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        }

  
        public  ProjectModel GetProjectData()
        {
            ProjectModel project  = new ProjectModel();

            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {

                SqlCommand cmd = new SqlCommand("sp_GetAllProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    project.projectName = sdr["projectName"].ToString();
                    project.projectDescription = sdr["projectDescription"].ToString();
                    project.status = sdr["status"].ToString();
                    project.clientCompany = sdr["clientCompany"].ToString();
                    project.projectLeader = sdr["projectLeader"].ToString();
                    project.estimatedBudget = sdr["estimatedBudget"].ToString();
                    project.totalAmountSpent = sdr["totalAmountSpent"].ToString();
                    project.estimatedProjectDuration = sdr["estimatedProjectDuration"].ToString();
                }
            }
            return project;
        }
    }
}
