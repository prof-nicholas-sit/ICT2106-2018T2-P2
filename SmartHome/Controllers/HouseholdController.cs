using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DAL.Mappers;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class HouseholdController : HomeController
    {
        // POST: Household/Edit/5
        private readonly AppLogCreator appLogCreator;

        public HouseholdController(IAppLogCreator ac)
        {
            appLogCreator = (AppLogCreator) ac;
        }

        public ActionResult Edit(int id)
        {
            return View(householduser);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string street, int postalCode, string unitNo, string surname, string contactNo, string email)
        {
            householduser.Street = street;
            householduser.PostalCode = postalCode;
            householduser.UnitNo = unitNo;
            householduser.Surname = surname;
            householduser.ContactNo = contactNo;
            householduser.Email = email;



            appLogCreator.AddLog(this, "UPDATEPROFILE", DateTime.Now);

            return View(nameof(Profile),householduser);
        }

        public ActionResult ViewNeighbours()
        {
           if (householduser.IsLogin != false)
            {
                model = (List<Household>) new HouseholdMapper().SelectAll();

                appLogCreator.AddLog(this, "VIEWNEIGHBOURS", DateTime.Now);

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

     
     

        public ActionResult Logout()
        {
            householduser.IsLogin = false;

            return RedirectToAction("Index","Home");
        }

        

    }

}