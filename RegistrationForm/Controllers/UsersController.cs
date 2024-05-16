using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class UsersController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
            //var user = db.Users.ToList();
            //return View(user);

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured!");
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Users user)
        {
            if(ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    var obj = db.Users.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                }
            }
            return View(user);
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] !=null)
            {
                return View();
            }
            else
            {
               return RedirectToAction("Login");
            }
        }
    }
}