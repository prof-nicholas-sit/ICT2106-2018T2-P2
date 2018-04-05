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
        public IActionResult Login(String username, String password)
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
                return RedirectToAction("Profile", "Household");

            }
            else
            {


                return View("Index");
            }
        }

        public ActionResult Profile()
        {
            _session = Session.getInstance;
            if ( _session.GetUser().GetType()==typeof(Household))
            {

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
