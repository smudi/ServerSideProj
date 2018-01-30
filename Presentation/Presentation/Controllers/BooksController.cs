using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Mockups;


namespace Presentation.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            var books = BookMockup.GetBooks();
            return View(books);
        }
        public ActionResult Info(int id)
        {
            var book = BookMockup.GetBooks().SingleOrDefault(b => b.Id == id);

            if (book == null) return HttpNotFound();

            return View(book);
        }
    }
}