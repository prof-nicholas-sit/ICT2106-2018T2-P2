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
        public ActionResult Details(String id)
        {
            if (AdminUser.IsLogin == true)
            {
                model = (List<Household>)new HouseholdMapper().SelectAll();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i)._id.ToString().Equals(id))
                    {
                       Household householdModel = model.ElementAt(i);
                       return View(householdModel);
                    }
                }
                
            }
            return RedirectToAction("Index", "Home");
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

    
     
        public ActionResult Edit(String id)
        {
            if (AdminUser.IsLogin == true)
            {
                model = (List<Household>)new HouseholdMapper().SelectAll();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i)._id.ToString().Equals(id))
                    {
                        Household householdModel = model.ElementAt(i);
                        return View(householdModel);
                    }
                }

            }
            return RedirectToAction("Index", "Home");
            
        }


        // POST: Admin/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(String householdID, [Bind("_id","Street", "PostalCode","UnitNo","Surname","ContactNo","Email","Password")]Household household)
        {
            if (AdminUser.IsLogin == true)
            {
                try
                {
                    if (AdminUser.IsLogin)
                    {
                        model = (List<Household>)new HouseholdMapper().SelectAll(); ;
                        System.Diagnostics.Debug.WriteLine("HouseholdID is: " + householdID);
                        System.Diagnostics.Debug.WriteLine(household._id.ToString() +","+household.Street +","+household.PostalCode+","+household.UnitNo+","+household.Surname+","+household.ContactNo+","+household.Email+","+household.Password);
                        for (int i = 0; i < model.Count(); i++)
                        {
                            if (model.ElementAt(i)._id.ToString().Equals(householdID))
                            {
                                model.ElementAt(i).Street = household.Street;
                                model.ElementAt(i).PostalCode = household.PostalCode;
                                model.ElementAt(i).UnitNo = household.UnitNo;
                                model.ElementAt(i).Surname = household.Surname;
                                model.ElementAt(i).ContactNo = household.ContactNo;
                                model.ElementAt(i).Email = household.Email;
                                model.ElementAt(i).Password = household.Password;
                            }
                        }

                    }

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
            }
            return RedirectToAction("Index", "Home");
           
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(String id)
        {
           if (AdminUser.IsLogin)
            {
                Household household1 = new Household();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i)._id.ToString() == id)
                    {
                        household1 = model.ElementAt(i);
                        new HouseholdMapper().Delete(household1._id).Save().Commit();
                        
                    }

                }


                return View(household1);



            }
      
            else
            {
                return RedirectToAction("Index", "Home");
            }
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