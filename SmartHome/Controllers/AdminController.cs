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
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                model = (List<Household>) new HouseholdMapper().SelectAll();
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
            _session = Session.getInstance;
            if (_session.IsLogin() == true)
            {
                model = (List<Household>) new HouseholdMapper().SelectAll();


                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        //Get Admin/adminDetails

        public ActionResult adminRequest()

        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                model = new List<Household>();

                List<Household> temp = (List<Household>) new HouseholdMapper().SelectAll();
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (temp.ElementAt(i).IsResetPassword)
                    {
                        Household householdModel = temp.ElementAt(i);
                        model.Add(householdModel);
                    }
                }
            }


            return View(model);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string street, int postalCode, string unitNo, string surname, string contactNo,
            string email, string password)
        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                try
                {
                    string[] UnitNoArray = unitNo.Split("#");

                    string username = postalCode.ToString() + "-" + UnitNoArray[1];


                    UserTypeFactory.CreateHousehold(username, password, email, street, postalCode, unitNo, surname,
                        contactNo);



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
            
        }



        public ActionResult Edit(String id)
        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                model = (List<Household>) new HouseholdMapper().SelectAll();
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
        public ActionResult Update(String id,
            [Bind("_id", "Street", "PostalCode", "UnitNo", "Surname", "ContactNo", "Email", "Password")]
            Household household)
        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                try
                {
                    model = (List<Household>) new HouseholdMapper().SelectAll();
                    ;
                    for (int i = 0; i < model.Count(); i++)
                    {
                        if (model.ElementAt(i)._id.ToString().Equals(id))
                        {
                            model.ElementAt(i).Street = household.Street;
                            model.ElementAt(i).PostalCode = household.PostalCode;
                            model.ElementAt(i).UnitNo = household.UnitNo;
                            model.ElementAt(i).Surname = household.Surname;
                            model.ElementAt(i).ContactNo = household.ContactNo;
                            model.ElementAt(i).Email = household.Email;
                            model.ElementAt(i).Password = household.Password;
                            model.ElementAt(i).IsResetPassword = false;
                            new HouseholdMapper().Update(model.ElementAt(i)).Save().Commit();

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
            
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(String id)
        {
            _session = Session.getInstance;
            if (_session.IsLogin())
            {
                Household household1 = new Household();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (model.ElementAt(i)._id.ToString() == id)
                    {
                        household1 = model.ElementAt(i);
                        new HouseholdMapper().Delete(model.ElementAt(i)._id).Save().Commit();

                    }

                }


                return View(household1);



            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(String id, IFormCollection collection)
        {
            try
            {
                _session = Session.getInstance;
                if (_session.IsLogin())
                {
                    return RedirectToAction(nameof(DashBoard));
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View("DashBoard");
            }
            
        }



        public ActionResult ProfileEdit(int id)
        {
            _session = Session.getInstance;
            return View((Administrator) _session.GetUser());
        }

        public ActionResult ProfileUpdate(string Username, string email, string password)
        {
            _session = Session.getInstance;
            if (_session.GetUser().GetType() == typeof(Administrator))
            {
                Administrator AdminUser = (Administrator) _session.GetUser();
                AdminUser.Username = Username;
                AdminUser.Email = email;
                AdminUser.Password = password;
                new AdminMapper().Update(AdminUser).Save().Commit();

                return View(nameof(Profile), AdminUser);
            }

            return RedirectToAction("Index", "Home");
        }



        public ActionResult Logout()
        {
            _session = Session.getInstance;
            Administrator AdminUser = (Administrator) _session.GetUser();
            AdminUser.IsLogin = false;
            _session.endSession();
            new AdminMapper().Update(AdminUser).Save().Commit();

            return RedirectToAction("Index", "Home");
        }

    }
}