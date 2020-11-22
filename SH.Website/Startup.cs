using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SH.Website.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SH.Website.Services;
using AutoMapper;
using SH.Website.Models.ViewModels;
using SH.Website.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SH.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
                //.AddJwtBearer(options =>
                //{
                //    options.SaveToken = true;
                //    options.RequireHttpsMetadata = false;
                //    options.TokenValidationParameters = new TokenValidationParameters()
                //    {
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidAudience = Configuration["JWT:ValidAudience"],
                //        ValidIssuer = Configuration["JWT:ValidIssuer"],
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                //    };
                //});
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IDAL,DAL>();
            services.AddTransient<IFactory, Factory>();

            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<ContactModel, ContactViewModel>().ReverseMap();
            }).CreateMapper();
            services.AddSingleton(mapper);

            //var mappe = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<LoginModel, LoginViewModel>().ReverseMap();
            //}).CreateMapper();
            //services.AddSingleton(mappe);

            //var mapp = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<RegisterModel, RegisterViewModel>().ReverseMap();
            //}).CreateMapper();
            //services.AddSingleton(mapp);



            //var dataCache = new DataCache(new Factory(new DAL(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))));
            //services.AddSingleton<IDataCache>(dataCache);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
