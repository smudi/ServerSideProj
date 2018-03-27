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
        //--------------------------------------------------------ADD--------------------------------------------------------
        public ActionResult Register()
        {
            if (Session["user"] == null || (int)Session["userRank"] == 0) //if not admin or not logged in you cant add new user
                return RedirectToAction("Index");

            User user = new User();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Service.Models.User user, bool isAdmin)
        {
            if (user.UserName == null || user.HashPassWord == null || user.ConfirmPassWord == null)
            {
                ViewBag.DuplicateMessage = "All fields must be filled in";
                return View();
            }
            if (Service.Models.User.getUserByName(user.UserName) != null)
            {
                ViewBag.DuplicateMessage = "username already exists";
                return View(user);
            }
            if (user.HashPassWord != user.ConfirmPassWord)
            {
                ViewBag.ComparePassword = "Password does not match";
                return View(user);
            }
            //Create hash password
            user.SaltNum = Crypto.GenerateSalt();
            user.HashPassWord = Crypto.Hash(user.SaltNum + user.HashPassWord);

            if (isAdmin) user.UserRank = 1;
            else user.UserRank = 0;

            Service.Models.User.Add(user);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            User user = new User();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorize(Service.Models.User user)
        {            
            //Check if real password is same as the paramenter value
            if (Service.Models.User.getUserByName(user.UserName) == null ||
                Service.Models.User.getUserByName(user.UserName).HashPassWord != Crypto.SHA256(Service.Models.User.getUserByName(user.UserName).SaltNum + user.HashPassWord))
            {
                ViewBag.ErrorMessage = "username or password is wrong";
                return View("Login");
            }
            //User is logged in, set session
            Session["user"] = Service.Models.User.getUserByName(user.UserName);
            Session["userName"] = Service.Models.User.getUserByName(user.UserName).UserName;
            Session["userRank"] = Service.Models.User.getUserByName(user.UserName).UserRank;

            return RedirectToAction("Index", "Home");
        }
        //--------------------------------------------------------LOGOUT--------------------------------------------------------
        public ActionResult Logout(Service.Models.User user)
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}