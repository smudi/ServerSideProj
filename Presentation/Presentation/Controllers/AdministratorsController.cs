using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Mockups;

namespace Presentation.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
    }
}