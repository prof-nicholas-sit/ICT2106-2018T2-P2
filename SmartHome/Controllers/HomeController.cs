﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using System.Text.RegularExpressions;
using SmartHome.DAL.Mappers;

namespace SmartHome.Controllers
{
    public class HomeController : Controller
    {
        public static List<Household> model = new List<Household>();
        public static Household householduser = new Household();
        public static Administrator AdminUser = new Administrator();

        public IActionResult Index()
        {
            return View();
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromServices] IAppLogCreator appLogCreator, String username, String password)
        {
            //ser loginUser = new User(username, password);

           IUser user = UserTypeFactory.CreateUser(username,password);


            if (user.GetType() == typeof(Administrator))
            {
                AdminUser = (Administrator) user;
                AdminUser.IsLogin = true;
                return RedirectToAction("Profile","Admin");
            }
            else if (user.GetType() == typeof(Household))
            {
                householduser = (Household) user;
                householduser.IsLogin = true;

                appLogCreator.setHouseholdId(householduser._id);
                appLogCreator.AddLog(this, "LOGIN", DateTime.Now);
                return RedirectToAction("Profile", "Household");

            }
            return View("Index");
        }

        public ActionResult Profile()
        {
            if (householduser.IsLogin == true)
            {

                return View(householduser);
            }
            else if (AdminUser.IsLogin == true)
            {
                return View(AdminUser);
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

       
       


    }
}
