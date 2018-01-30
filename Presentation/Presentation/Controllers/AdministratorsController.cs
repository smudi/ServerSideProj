using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Mockups;

namespace Presentation.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            return View(repo.AdminList);
        }

        public ActionResult Info(int id)
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            var admin = repo.AdminList.SingleOrDefault(b => b.Id == id);

            if (admin == null) return HttpNotFound();

            return View(admin);
        }
    }
}