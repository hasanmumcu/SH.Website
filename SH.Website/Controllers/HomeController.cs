﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SH.Website.Authentication;
using SH.Website.Models;
using SH.Website.Services;
using System.Security.Principal;
using System.Data.SqlClient;
using System.Collections.Generic;
using SH.Website.Models.ViewModels;
using System.Linq;
using System;
using System.Data;
using SH.Website.Data;
using Microsoft.EntityFrameworkCore;

namespace SH.Website.Controllers
{
    //[Authorize(Roles.DIRECTOR, Roles.USER, Roles.ANALYST)]
    public class HomeController : Controller
    {
        protected IFactory _factory;
        private readonly ILogger<HomeController> _logger;
        private readonly System.Collections.Generic.List<AdminContactModel> AdminContactList = new System.Collections.Generic.List<AdminContactModel>();
        private readonly System.Collections.Generic.List<AnalystContactModel> AnalystContactList = new System.Collections.Generic.List<AnalystContactModel>();
        private readonly System.Collections.Generic.List<AnalystContactModel> UserContactList = new System.Collections.Generic.List<AnalystContactModel>();
        private readonly System.Collections.Generic.List<ProjectModel> ProjectList = new System.Collections.Generic.List<ProjectModel>();
        private readonly System.Collections.Generic.List<string> allProjects = new System.Collections.Generic.List<string>();
        protected IApplicationDbContext _context;
        private readonly IDAL _dal;
        private readonly System.Collections.Generic.List<ProjectModel> EditSelectList = new System.Collections.Generic.List<ProjectModel>();
        private readonly System.Collections.Generic.List<ProjectModel> AnalystPageProjects = new System.Collections.Generic.List<ProjectModel>();

        public HomeController(ILogger<HomeController> logger, IFactory factory, IApplicationDbContext context, IDAL dal)
        {
            _logger = logger;
            _factory = factory;
            _context = context;
            _dal = dal;
        }

        
        


        public async Task<IActionResult> Index()
        {
            return View(await _factory.GetIndexViewModel());
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}
        public IActionResult Login()
        { 
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Analyst()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ErrorToProjects()
        {
            return View();
        }
        public IActionResult Projects()
        {
            ViewBag.Message = _dal.GetProjectData();

            return View();
        }
        public IActionResult ProjectAdd()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Edit_project()
        {

            ViewBag.Message = _dal.GetProjectData();

            return View();
        }




        public IActionResult deleteFromAnalyst(string subject)
        {

            _dal.DeleteMessageFromAnalyst(subject);

            return RedirectToAction("Analyst");
        }

        public IActionResult deleteFromAdmin(string subject)
        {

            _dal.DeleteMessageFromAdmin(subject);

            return RedirectToAction("Dashboard");

        }

        public IActionResult deleteFromUser(string subject)
        {

            _dal.DeleteMessageFromUser(subject);

            return RedirectToAction("User");
        }
        public IActionResult LoginUser(User user)
        {

            TokenProvider _tokenProvider = new TokenProvider();
            //Authenticate user
            var userToken = _tokenProvider.LoginUser(user.Email.Trim(), user.Password.Trim());
            if (userToken != null)
            {
                //Save token in session object
                HttpContext.Session.SetString("JWToken", userToken);
            }
            return Redirect("~/Home/Login");
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public IActionResult Register()
        {
            var context = _dal.GetRegistersData();
            int counter = 0;
            int counter1 = 0;

            RegisterModel registerModelToOwner = new RegisterModel();

            registerModelToOwner.Id = Guid.Parse("cda8118c-fdd9-4ba9-938e-bff705c29980");
            registerModelToOwner.Name = "Hasan";
            registerModelToOwner.Password = "hasanmumcu";
            registerModelToOwner.ACCESS_LEVEL = "DIRECTOR";
            registerModelToOwner.Active = true;
            registerModelToOwner.ConfirmPassword = "hasanmumcu";
            registerModelToOwner.Timestamp = System.DateTime.Parse("01/10/2021 5:50");
            registerModelToOwner.WRITE_ACCESS = "WRITE_ACCESS";
            registerModelToOwner.Email = "hasan.mumcu@ceng.deu.edu.tr";
            foreach (var item in context)
            {
                if (item == registerModelToOwner.Email)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
          
                    _dal.Initial(registerModelToOwner);
                
            }



            RegisterModel registerModelToAnalyst = new RegisterModel();
            registerModelToAnalyst.Id = Guid.Parse("ac56e595-0c00-4139-8f02-cc069726d5a1");
            registerModelToAnalyst.Name = "Sibel";
            registerModelToAnalyst.Password = "sibelkara";
            registerModelToAnalyst.ACCESS_LEVEL = "ANALYST";
            registerModelToAnalyst.Active = true;
            registerModelToAnalyst.ConfirmPassword = "sibelkara";
            registerModelToAnalyst.Timestamp = System.DateTime.Parse("01/10/2021 5:50");
            registerModelToAnalyst.WRITE_ACCESS = "WRITE_ACCESS";
            registerModelToAnalyst.Email = "sibel.kara@ceng.deu.edu.tr";

            foreach (var item in context)
            {
                if (item == registerModelToAnalyst.Email)
                {
                    counter1++;
                }
            }
            if (counter1 == 0)
            {

                _dal.Initial(registerModelToAnalyst);

            }


            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Compose()
        {
            return View();
        }

        public IActionResult AnalystCompose()
        {
            return View();
        }
        public IActionResult UserCompose()
        {
            return View();
        }
        public IActionResult MailBox()
        {


             ViewBag.Message = _dal.AdminMailBox();

            return View();

        }
        public IActionResult AnalystMailBox()
        {

            //ViewData["Message"] = adminContactModel;
            ViewBag.Message = _dal.AnalystMailBox();

            return View();

        }
        public IActionResult UserMailBox()
        {


            ViewBag.Message = _dal.UserMailBox();

            return View();

        }
        public IActionResult ReadMail()
        {

            ViewBag.Message = _dal.AdminMailBox();

            return View();

        }
        public IActionResult AnalystReadMail()
        {

            //ViewData["Message"] = adminContactModel;
            ViewBag.Message = _dal.AnalystMailBox();

            return View();

        }

        public IActionResult UserReadMail()
        {

            ViewBag.Message = _dal.UserMailBox();

            return View();

        }


    }
}
