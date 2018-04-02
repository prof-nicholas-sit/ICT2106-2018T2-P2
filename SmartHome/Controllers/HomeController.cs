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
        public IActionResult Login(String username, String password)
        {
            householduser.Username = username;
            householduser.ContactNo = "97884440";
            householduser.PostalCode = 670140;
            householduser.Street = "140 Petir Road";
            householduser.Surname = "Lee";
            householduser.UnitNo = "#06-328";
            householduser.Email = "l.kokleong1991@gmail.com";
            householduser.Password = password;
            
            //AdminUser.Email = "admin01@gmail.com";
            //AdminUser.Username = username;
            //AdminUser.Password = password;

            new HouseholdMapper().Create(householduser).Save().Commit();

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
                return RedirectToAction("Profile", "Household");

            }

            /*if (user.getUsername().Equals(AdminUser.Username) && user.getPassword().Equals(AdminUser.password))
            {
                var household2 = new HouseholdModel("213810-10-128", "password", "Kangfamily@email.com", 1, "810 Yio Chu Kang Avenue 11", 213810, "#10-128", "Kang", "8194029");


                var household3 = new HouseholdModel("423432-08-231", "password", "Ongfamily@email.com", 2, "421 Dover Avenue 11", 423432, "#08-231", "Ong", "92555235");



                model.Add(household2);


                model.Add(household3);
                AdminUser.isLogin = true;*/
                   /* try
                    {
                        // TODO: Add insert logic here


                        return RedirectToAction("Profile","Admin");
                    }
                    catch
                    {
                        return View("Index");
                    }
            }
            else if (user.GetType() == typeof(Household))
            {
                /* if (user.getUsername() == householduser.Username && user.getPassword() == householduser.password)
                 {*/
               /* householduser.IsLogin = true;
                try
                {
                    // TODO: Add insert logic here
                    return RedirectToAction("Profile", "Household");
                }
                catch
                {
                    return View("Index");
                }
            }
            //}
            else
                {
                    return View("Index");
                }*/

     

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
