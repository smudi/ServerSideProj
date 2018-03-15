using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;

namespace Presentation.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View(Service.Models.User.getAdministrators());
        }
        public ActionResult Info(string id)
        {
            var x = Book.getBook(id);
            return View(x);
        }
        //---------------EDIT---------------
        public ActionResult Edit(int id)
        {
            return View(Service.Models.User.getUser(id));
        }
        [HttpPost]
        public RedirectToRouteResult Edit(Service.Models.User admin)
        {
            TempData["admin"] = admin;
            return RedirectToAction("Update");
        }
        public RedirectToRouteResult Update()
        {
            Service.Models.User.Update(TempData["admin"] as Service.Models.User);
            return RedirectToAction("Index", "Users");
        }
    }
}