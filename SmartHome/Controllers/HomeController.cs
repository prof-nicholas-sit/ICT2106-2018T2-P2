using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;
using System.Text.RegularExpressions;

namespace SmartHome.Controllers
{
    public class HomeController : Controller
    {
        public static List<HouseholdModel> model = new List<HouseholdModel>();
        public static HouseholdModel householduser = new HouseholdModel("111111-07-328", "password", "koh@email.com", 1, "148 Peitr road", 1111, "#07-328", "Koh", "98765432");
        public static AdminModel AdminUser = new AdminModel("admin01", "password", "admin01@email.com", 1);

        public IActionResult Index()
        {
            return View();
        }

        

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(String username, String password)
        {

            User loginUser = new User(username, password);

            IUser user = UserTypeFactory.CreateUser(loginUser);
            

            if (user.GetType()==typeof(AdminModel))
            {

                if (user.getUsername().Equals(AdminUser.Username) && user.getPassword().Equals(AdminUser.password))
                {
                    var household2 = new HouseholdModel("213810-10-128", "password", "Kangfamily@email.com", 1, "810 Yio Chu Kang Avenue 11", 213810, "#10-128", "Kang", "8194029");


                    var household3 = new HouseholdModel("423432-08-231", "password", "Ongfamily@email.com", 2, "421 Dover Avenue 11", 423432, "#08-231", "Ong", "92555235");



                    model.Add(household2);


                    model.Add(household3);
                    AdminUser.isLogin = true;
                    try
                    {


                        // TODO: Add insert logic here


                        return RedirectToAction("Profile","Admin");
                    }
                    catch
                    {
                        return View("Index");
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            else if (user.GetType() == typeof(HouseholdModel))
            {
                if (user.getUsername() == householduser.Username && user.getPassword() == householduser.password)
                {
                    householduser.isLogin = true;
                    try
                    {
                        // TODO: Add insert logic here
                        return RedirectToAction("Profile","Household");
                    }
                    catch
                    {
                        return View("Index");
                    }
                }
                else
                {
                    return View("Index");
                }

            
            }

            return View("Index");
        }

        public ActionResult Profile()
        {
            if (householduser.isLogin == true)
            {

                return View(householduser);
            }
            else if (AdminUser.isLogin == true)
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
