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
        public ActionResult Register(Service.Models.User user)
        {
          if(Service.Models.User.getUserByName(user.UserName) != null)
            {
                ViewBag.DuplicateMessage = "username already exists";
                return View(user);
            }        
          if(user.HashPassWord != user.ConfirmPassWord)
            {
                ViewBag.ComparePassword = "Password does not match";
                return View(user);
            }
            user.UserRank = 0;
            Service.Models.User.Add(user);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            User user = new User();
            return View();
        }
        [HttpPost]
        public ActionResult Authurize(Service.Models.User user)
        {
            if(Service.Models.User.getUserByName(user.UserName) == null ||
                Service.Models.User.getUserByName(user.UserName).HashPassWord != user.HashPassWord)
            {
                ViewBag.ErrorMessage = "username or password is wrong";
                return View(user);
            }
            Session["user"] = Service.Models.User.getUserByName(user.UserName);
            Session["userName"] = Service.Models.User.getUserByName(user.UserName).UserName;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout(Service.Models.User user)
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}