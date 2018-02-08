using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;

namespace Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            return View(Author.getAuthorList());
        }

        public ActionResult Info(int id)
        {
            return View(Author.getAuthor(id));
        }
    }
}