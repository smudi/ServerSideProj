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
            var administrator = AdministratorMockup.GetAdministrators();
            return View(administrator);
        }

        public ActionResult Info(int id)
        {
            var admin = AdministratorMockup.GetAdministrators().SingleOrDefault(b => b.Id == id);

            if (admin == null) return HttpNotFound();

            return View(admin);
        }
    }
}