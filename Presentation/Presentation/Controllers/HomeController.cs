using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Mockups;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RepositoryMockup repo = new RepositoryMockup();
            Session["repo"] = repo;
            return View();
        }
    }
}