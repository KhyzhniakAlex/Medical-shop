using Medical_shop.Models.Entities;
using Medical_shop.Models.Services;
using Medical_shop.Models.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Medical_shop.Controllers
{
    public class AuthorityController : Controller
    {
        public ActionResult Log_in()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Log_in(LoginModel model)
        {
            //bool check = false;
            //HomeServices hs = new HomeServices();
            //model = hs.Login(model, check);
            //if (check) RedirectToAction("Contacts", "Home");
            if (ModelState.IsValid)
            {
                User user = null;
                using (MedicalContext db = new MedicalContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name && u.Password == model.Password);
                }
                if (user != null)
                {
                    Order order = null;
                    int userID = 0;
                    MedicalContext db = new MedicalContext();
                    foreach (var item in db.Users)
                    {
                        if (item.Login == model.Name)
                            userID = item.Id;
                    }
                    foreach (var item in db.Orders)
                    {
                        if (item.UserId == userID) order = item;
                    }
                    if (order == null)
                    {
                        order = new Order { Id = db.Orders.Max(p => p.Id) + 1, UserId = userID };
                        Session["Order"] = order;
                        db.Orders.Add(order);
                    }
                    else Session["Order"] = order;
                    db.SaveChanges();

                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Main", "Home");
                }
                else ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }

            return View(model);
        }




        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationModel model)
        {
            //bool check = false;
            //HomeServices hs = new HomeServices();
            //model = hs.Registration(model, check);
            //if (check) RedirectToAction("Contacts", "Home");
            if (ModelState.IsValid)
            {
                User user = null;
                using (MedicalContext db = new MedicalContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (MedicalContext db = new MedicalContext())
                    {
                        bool special = false;
                        foreach (var item in db.RulesForAdmin)
                        {
                            if (item.RulePassword == model.SpecialPassword)
                            {
                                db.Users.Add(new User { Login = model.Name, Email = model.Email, Password = model.Password, Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Role = "Admin" });
                                db.RulesForAdmin.Remove(item);
                                special = true;
                                break;
                            }
                        }
                        if (!special) db.Users.Add(new User { Login = model.Name, Email = model.Email, Password = model.Password, Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Role = "Client" });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        MedicalContext db = new MedicalContext();
                        var firstOrder = new Order { Id = db.Orders.Max(p => p.Id) + 1, UserId = db.Users.Max(p => p.Id) };
                        Session["Order"] = firstOrder;
                        db.Orders.Add(firstOrder);
                        db.SaveChanges();

                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Main", "Home");
                    }
                }
                else ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }




        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Home");
        }

        //public string Index()
        //{
        //    string result = "Вы не авторизованы";
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        result = "Ваш логин: " + User.Identity.Name;
        //    }
        //    return result;
        //}
    }
}