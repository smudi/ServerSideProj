using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Mockups;
using Service.Models;

namespace Presentation.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            return View(repo.BookList);
        }
        public ActionResult Info(int id)
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            var book = repo.BookList.SingleOrDefault(b => b.Id == id);

            if (book == null) return HttpNotFound();

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            var book = repo.BookList.SingleOrDefault(b => b.Id == id);

            if (book == null) return HttpNotFound();

            return View(book);
        }
        [HttpPost]
        public RedirectToRouteResult Edit(String Name, String Id, String Information, String Author)
        {
            TempData["id"] = Convert.ToInt32(Id);
            TempData["name"] = Name;
            TempData["information"] = Information;
            return RedirectToAction("Update");
        }

        public RedirectToRouteResult Update()
        {
            RepositoryMockup repo = (RepositoryMockup)Session["repo"];
            Book bookObj = repo.BookList.Find(x => x.Id == Convert.ToInt32(TempData["id"]));
            bookObj.Name = Convert.ToString(TempData["name"]);
            bookObj.Information = Convert.ToString(TempData["information"]);
            Session["repo"] = repo;
            return RedirectToAction("Info", "Books");
        }
    }
}