using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class HouseholdController : HomeController
    {
        // POST: Household/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View(householduser);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string street, int postalCode, string unitNo, string surname, string contactNo, string email)
        {
            householduser.street = street;
            householduser.postalCode = postalCode;
            householduser.unitNo = unitNo;
            householduser.surname = surname;
            householduser.contactNo = contactNo;
            householduser.email = email;

            return View(nameof(Profile),householduser);
        }

        public ActionResult ViewNeighbours()
        {
            if (householduser.isLogin != false)
            {
                var household2 = new HouseholdModel();
                household2.surname = "Kang";
                household2.street = "810 Yio Chu Kang Avenue 11";
                household2.unitNo = "#10-128";
                household2.postalCode = 213810;
                household2.contactNo = "+65 80194029";
                household2.email = "Kangfamily@email.com";
                household2.password = "password";
                household2.houseHoldID = 4;
                household2.Username = "213810-10-218";

                var household3 = new HouseholdModel();
                household3.surname = "Ong";
                household3.street = "421 Dover Avenue 11";
                household3.unitNo = "#08-231";
                household3.postalCode = 423432;
                household3.contactNo = "+65 92555235";
                household3.email = "Ongfamily@email.com";
                household3.password = "password";
                household3.houseHoldID = 3;
                household3.Username = "423432-08-231";

                    model.Add(household2);
                
             
                    model.Add(household3);
                
                return View(model);
            }
            else
            {
                return View("Login");
            }
        }

     
     

        public ActionResult Logout()
        {
            householduser.isLogin = false;

            return RedirectToAction("Index","Home");
        }

        

    }

}