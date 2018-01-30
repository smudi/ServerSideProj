﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Mockups;

namespace Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            var author = AuthorMockup.GetAuthors();
            return View(author);
        }

        public ActionResult Info(int id)
        {
            var author = AuthorMockup.GetAuthors().SingleOrDefault(b => b.Id == id);

            if (author == null) return HttpNotFound();

            return View(author);
        }
    }
}