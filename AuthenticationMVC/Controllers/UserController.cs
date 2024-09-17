using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthenticationMVC.Data;
using AuthenticationMVC.Models;
using AuthenticationMVC.ViewModels;

namespace AuthenticationMVC.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LogIn(LoginVM loginVM)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<User>().FirstOrDefault(u => u.UserName == loginVM.UserName);
                    if (user != null)
                    {
                        if(BCrypt.Net.BCrypt.Verify(loginVM.Password,user.Password))
                        {
                            FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                            return RedirectToAction("Index", "Employee");
                        }
                    }
                    ModelState.AddModelError("", "Username/Password Doesn't Exist");
                    return View();
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    session.Save(user);
                    txn.Commit();
                    return RedirectToAction("LogIn");
                }
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}