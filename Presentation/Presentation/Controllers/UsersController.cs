using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;

namespace Presentation.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
          if(Service.Models.User.getUserByName(user.UserName) != null)
            {
                ViewBag.DuplicateMessage = "username already exists";
                User _user = new User();
                return View(_user);
            }
            user.UserRank = 0;
            Service.Models.User.Add(user);
            return RedirectToAction("Index", "Home");
        }
    }
}