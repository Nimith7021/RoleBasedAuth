using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationMVC.Data;
using AuthenticationMVC.Models;

namespace AuthenticationMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var data = session.Query<Employee>().ToList();             
                return View(data);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]

        public ActionResult Create(Employee employee) {

            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    
                    session.Save(employee);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}