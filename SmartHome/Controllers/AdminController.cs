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
    public class AdminController : HomeController

     
    {
        public ActionResult Details(int id)
        {
            /*HouseholdModel household = new HouseholdModel();
            if (AdminUser.isLogin)
            {
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i).houseHoldID == id)
                    {
                        household = model.ElementAt(i);
                    }
                }

                return View(household);
            }*/

            return View();
        }
        
        // GET: Admin
        public ActionResult DashBoard()
        {
            if (AdminUser.IsLogin == true)
            {
                model = (List<Household>) new HouseholdMapper().SelectAll();
              
                
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

  
        //Get Admin/adminDetails
        
        public ActionResult adminRequest()

        {
           /* if (AdminUser.isLogin == true) { 
            return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }*/
            return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            if (AdminUser.IsLogin)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string street,int postalCode,string unitNo,string surname,string contactNo,string email, string password)
        {
            if (AdminUser.IsLogin)
            {
                try
                {
                    string[] UnitNoArray = unitNo.Split("#");

                    string username = postalCode.ToString() + "-" + UnitNoArray[1];
                    
                    
                    UserTypeFactory.CreateHousehold(username,password,email,street, postalCode,unitNo,surname,contactNo );
                    
                   

                    return RedirectToAction(nameof(DashBoard));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    
     
        public ActionResult Edit(int id)
        {
            /*HouseholdModel household = new HouseholdModel();
            if (AdminUser.isLogin)
            {
                for(int i = 0; i <model.Count(); i++)
                {
                    if(model.ElementAt(i).houseHoldID == id)
                    {
                        household = model.ElementAt(i);
                    }
                }

                return View(household);
            }*/

            return View();

        }


        // POST: Admin/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int householdID, [Bind("street", "postalCode","unitNo","surname","contactNo","email","password")]Household household)
        {
            /*if (AdminUser.isLogin == true)
            {
                try
                {
                    if (AdminUser.isLogin)
                    {

                        for (int i = 0; i < model.Count(); i++)
                        {
                            if (model.ElementAt(i).houseHoldID == householdID)
                            {
                                model.ElementAt(i).street = household.street;
                                model.ElementAt(i).postalCode = household.postalCode;
                                model.ElementAt(i).unitNo = household.unitNo;
                                model.ElementAt(i).surname = household.surname;
                                model.ElementAt(i).contactNo = household.contactNo;
                                model.ElementAt(i).email = household.email;
                                model.ElementAt(i).password = household.password;
                            }
                        }

                    }
                    // TODO: Add update logic here

                    return RedirectToAction(nameof(DashBoard));
                }
                catch
                {
                    return View("DashBoard");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }*/
            return RedirectToAction("Index", "Home");
           
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
           /* if (AdminUser.isLogin)
            {
                HouseholdModel household1 = new HouseholdModel();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i).houseHoldID == id)
                    {
                        household1 = model.ElementAt(i);
                    }

                }


                return View(household1);



            }
      
            else
            {
                return RedirectToAction("Index", "Home");
            }*/
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
           /* try
            {
                // TODO: Add delete logic here
                if (AdminUser.isLogin)
                {
                 
                    for (int i = 0; i < model.Count(); i++)
                    {
                        if (model.ElementAt(i).houseHoldID == id)
                        {
                            model.RemoveAt(i);
                        }

                    }


                    //return View(household1);



                }



                return RedirectToAction(nameof(DashBoard));
            }
            catch
            {
                return View();
            }*/
            return View();
        }

       

        public ActionResult ProfileEdit(int id)
        {
            return View(AdminUser);
        }

        public ActionResult ProfileUpdate(string Username, string email, string password)
        {
            AdminUser.Username = Username;
            AdminUser.Email = email;
            AdminUser.Password = password;
            new AdminMapper().Update(AdminUser).Save().Commit();

            return View(nameof(Profile), AdminUser);
        }


        public ActionResult Logout()
        {
            AdminUser.IsLogin = false;
            new AdminMapper().Update(AdminUser).Save().Commit();

            return RedirectToAction("Index", "Home");
        }

    }
}