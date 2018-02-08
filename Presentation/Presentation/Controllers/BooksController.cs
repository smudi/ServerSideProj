using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;

namespace Presentation.Controllers
{
    public class BooksController : Controller
    {
     
        // GET: Books
        public ActionResult Index()
        {       
            return View(Book.getBookList());
        }
        public ActionResult Info(string id)
        {
            return View(Book.getBook(id));
        }

        public ActionResult Edit(string id)
        {
            return View(Book.getBook(id));
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