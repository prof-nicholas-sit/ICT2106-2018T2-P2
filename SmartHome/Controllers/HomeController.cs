﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using System.Text.RegularExpressions;
 using SmartHome.DAL.Mappers;
using SmartHome.AppLogging;

namespace SmartHome.Controllers
{
    public class HomeController : Controller
    {
        protected static List<Household> model = new List<Household>();
        protected Session _session;
        
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult SendRequest(String Username)
        {
            new HouseholdMapper().RequestPasswordReset(Username).Save().Commit();
            return View("Index");
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromServices] IAppLogCreator appLogCreator, [FromServices] IAppLogRetriever appLogRetriever, String username, String password)
        {


          IUser user = UserTypeFactory.CreateUser(username,password);


            if ( user!=null&& user.GetType() == typeof(Administrator))
            {
                Administrator AdminUser = (Administrator) user;
                AdminUser.IsLogin = true;
                _session= Session.getInstance;
                _session.setCurrentUser(AdminUser);
                new AdminMapper().Update(AdminUser).Save().Commit();
                return RedirectToAction("Profile","Admin");
            }
            else if (user!=null&&user.GetType() == typeof(Household))
            {
                Household householduser = (Household) user;
                householduser.IsLogin = true;
                _session = Session.getInstance;
                _session.setCurrentUser(householduser);
                new HouseholdMapper().Update(householduser).Save().Commit();

                appLogRetriever.SetHouseholdId(householduser._id);
                appLogCreator.SetHouseholdId(householduser._id);
                appLogCreator.AddLog(this, "ACTION*/-LOGIN", DateTime.Now);

                return RedirectToAction("Profile", "Household");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Profile([FromServices] IAppLogCreator appLogCreator)
        {
            _session = Session.getInstance;
            if ( _session.GetUser().GetType()==typeof(Household))
            {
                if (_session.isFromLogin()) //Do not count initial profile "Visit" upon login
                {
                    Console.WriteLine("Redirect to profile page from login");
                } else
                {
                    appLogCreator.AddLog(this, "PAGE*/-View-Profile", DateTime.Now);
                }
                return View((Household)_session.GetUser());
            }
            else if (_session.IsLogin()== true && _session.GetUser().GetType() == typeof(Administrator))
            {
                return View(_session.GetUser());
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}