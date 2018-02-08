using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Info(int id)
        //{
        //    RepositoryMockup repo = (RepositoryMockup)Session["repo"];
        //    var admin = repo.AdminList.SingleOrDefault(b => b.Id == id);

        //    if (admin == null) return HttpNotFound();

        //    return View(admin);
        //}
    }
}