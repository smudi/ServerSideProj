using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            LibDb db = new LibDb();
            return View(db.AUTHORs.ToList());
        }

        public ActionResult Info(int id)
        {
            LibDb db = new LibDb();
            BOOK book = new BOOK();
            AUTHOR author = db.AUTHORs.Where(a => a.Aid == id).FirstOrDefault();            
            if (author == null) return HttpNotFound();
            return View(author);
        }
    }
}