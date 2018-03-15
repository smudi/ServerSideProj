using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;
using System.Web.Helpers;

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
          //Hash password
            user.SaltNum = Crypto.GenerateSalt();
            user.HashPassWord = Crypto.Hash(user.SaltNum + user.HashPassWord);

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
        public ActionResult Authorize(Service.Models.User user)
        {
            // Get salt
            var salt = Service.Models.User.getUserByName(user.UserName).SaltNum; 

            //Check if real password is same as the paramenter value
            if (Service.Models.User.getUserByName(user.UserName) == null ||
                Service.Models.User.getUserByName(user.UserName).HashPassWord != Crypto.SHA256(salt + user.HashPassWord))
            {
                ViewBag.ErrorMessage = "username or password is wrong";
                return View("Login");
            }
            //User is logged in, set session
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