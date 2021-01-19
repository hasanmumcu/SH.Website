using SH.Website.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SH.Website.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SH.Website.Services
{
    public class DAL : IDAL
    {
        protected IApplicationDbContext _context;
        private readonly System.Collections.Generic.List<string> allProjects = new System.Collections.Generic.List<string>();
        private readonly System.Collections.Generic.List<AnalystContactModel> adminContacts = new System.Collections.Generic.List<AnalystContactModel>();
        private readonly System.Collections.Generic.List<AdminContactModel> anlaystContacts = new System.Collections.Generic.List<AdminContactModel>();
        private readonly System.Collections.Generic.List<AnalystContactModel> adminContact = new System.Collections.Generic.List<AnalystContactModel>();
        private readonly System.Collections.Generic.List<AnalystContactModel> userContact = new System.Collections.Generic.List<AnalystContactModel>();
        private readonly System.Collections.Generic.List<ProjectModel> projects  = new System.Collections.Generic.List<ProjectModel>();
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

        public void DeleteMessageFromAnalyst(string subject )
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {

                SqlCommand cmd = new SqlCommand("sp_DeleteMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Subject", subject);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
           
        }

        public void Initial(RegisterModel model)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_addInitialData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", model.ConfirmPassword);
                cmd.Parameters.AddWithValue("@ACCESS_LEVEL", model.ACCESS_LEVEL);
                cmd.Parameters.AddWithValue("@WRITE_ACCESS", model.WRITE_ACCESS);
                cmd.Parameters.AddWithValue("@Active", model.Active);
                cmd.Parameters.AddWithValue("@Timestamp", model.Timestamp);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public List<AnalystContactModel> AdminMailBox()
        {
            DateTime d;

            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllRowsOfViewAdminMailBox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    AnalystContactModel analystContactModel = new AnalystContactModel();
                    analystContactModel.to = sdr["to"].ToString();
                    analystContactModel.Subject = sdr["Subject"].ToString();
                    analystContactModel.Message = sdr["Message"].ToString();
                    analystContactModel.Timestamp = Convert.ToDateTime(sdr["Timestamp"]);
                    adminContact.Add(analystContactModel);

                }

            }
            return adminContact;
        }

        public List<AdminContactModel> AnalystMailBox()
        {
            
     
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllRowsOfViewAnalystMailBox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    AdminContactModel adminContactModel = new AdminContactModel();
                    adminContactModel.to = sdr["to"].ToString();
                    adminContactModel.Subject = sdr["Subject"].ToString();
                    adminContactModel.Message = sdr["Message"].ToString();
                    adminContactModel.Timestamp = Convert.ToDateTime(sdr["Timestamp"]);

                    anlaystContacts.Add(adminContactModel);
                }

            }
            return anlaystContacts;
        }

        public List<AnalystContactModel> UserMailBox()
        {

            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllRowsOfViewUserMailBox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                    AnalystContactModel analystContactModel = new AnalystContactModel();
                    analystContactModel.to = sdr["to"].ToString();
                    analystContactModel.Subject = sdr["Subject"].ToString();
                    analystContactModel.Message = sdr["Message"].ToString();
                    analystContactModel.Timestamp = Convert.ToDateTime(sdr["Timestamp"]);
                    userContact.Add(analystContactModel);

                }

            }
            return userContact;
        }
        public List<ProjectModel> GetProjectData()
        {


            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {

                SqlCommand cmd = new SqlCommand("sp_GetAllProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    ProjectModel project = new ProjectModel();
                    project.projectName = sdr["projectName"].ToString();
                    project.projectDescription = sdr["projectDescription"].ToString();
                    project.status = sdr["status"].ToString();
                    project.clientCompany = sdr["clientCompany"].ToString();
                    project.projectLeader = sdr["projectLeader"].ToString();
                    project.estimatedBudget = sdr["estimatedBudget"].ToString();
                    project.totalAmountSpent = sdr["totalAmountSpent"].ToString();
                    project.estimatedProjectDuration = sdr["estimatedProjectDuration"].ToString();
                    projects.Add(project);
                }
            }
            return projects;
        }
        public List<string>  GetRegistersData()
        {
            RegisterModel register = new RegisterModel();

            using (SqlConnection con = new SqlConnection("Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebAPP;Integrated Security=True;MultipleActiveResultSets=true"))
            {

                SqlCommand cmd = new SqlCommand("sp_GetAllRegisters", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    register.Name = sdr["Name"].ToString();
                    register.Email = sdr["Email"].ToString();
                    register.Password = sdr["Password"].ToString();
                    register.ConfirmPassword = sdr["ConfirmPassword"].ToString();
                    register.ACCESS_LEVEL = sdr["ACCESS_LEVEL"].ToString();
                    register.WRITE_ACCESS = sdr["WRITE_ACCESS"].ToString();
                    allProjects.Add(register.Email);
                }
            }
            return allProjects;
        }

        public async Task<AnalystContactModel> PostAnalystContact(AnalystContactModel model)
        {
            await _context.AnalystContacts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<UserContactModel> PostUserContact(UserContactModel model)
        {
            await _context.UserContacts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
