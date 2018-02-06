using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace Presentation.Controllers
{
    public class BooksController : Controller
    {
     
        // GET: Books
        public ActionResult Index()
        {
            LibDb db = new LibDb();          
            return View(db.BOOKs.ToList());
        }
        public ActionResult Info(string id)
        {
            LibDb db = new LibDb(); ;
            BOOK book = db.BOOKs.Where(b => b.ISBN == id).FirstOrDefault();

            if (book == null) return HttpNotFound();

            return View(book);
        }

        public ActionResult Edit(string id)
        {
            LibDb db = new LibDb();
            BOOK book = db.BOOKs.Where(b => b.ISBN == id).FirstOrDefault();
            if (book == null) return HttpNotFound();

            return View(book);
        }
        //[HttpPost]
        //public RedirectToRouteResult Edit(String Name, String Id, String Information, String Author)
        //{
        //    BOOK book = new BOOK();
        //    LibDb db = new LibDb();
        //    db.BOOKs.Where(b => b.ISBN == Id)
        //    db.BOOKs.a

        //    TempData["id"] = Convert.ToInt32(Id);
        //    TempData["name"] = Name;
        //    TempData["information"] = Information;

        //    return RedirectToAction("Update");
        //}

        //public RedirectToRouteResult Update()
        //{
        //    RepositoryMockup repo = (RepositoryMockup)Session["repo"];
        //    Book bookObj = repo.BookList.Find(x => x.Id == Convert.ToInt32(TempData["id"]));
        //    bookObj.Name = Convert.ToString(TempData["name"]);
        //    bookObj.Information = Convert.ToString(TempData["information"]);
        //    Session["repo"] = repo;
        //    return RedirectToAction("Info", "Books");
        //}
    }
}