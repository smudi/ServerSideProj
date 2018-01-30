using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Mockups;

namespace Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            return View(repo.AuthorList);
        }

        public ActionResult Info(int id)
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            var author = repo.AuthorList.SingleOrDefault(b => b.Id == id);

            if (author == null) return HttpNotFound();

            return View(author);
        }
    }
}