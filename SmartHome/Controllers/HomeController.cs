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
        private Session _session;
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
            
            
           

            //ser loginUser = new User(username, password);

          IUser user = UserTypeFactory.CreateUser(username,password);


            if ( user!=null&& user.GetType() == typeof(Administrator))
            {
                AdminUser = (Administrator) user;
                AdminUser.IsLogin = true;
                _session= Session.getInstance;
                _session.setCurrentUser(AdminUser);
                return RedirectToAction("Profile","Admin");
            }
            else if (user!=null&&user.GetType() == typeof(Household))
            {
                householduser = (Household) user;
                householduser.IsLogin = true;
                _session = Session.getInstance;
                _session.setCurrentUser(householduser);
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
