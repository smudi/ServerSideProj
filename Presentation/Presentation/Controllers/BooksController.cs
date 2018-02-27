using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;
using Presentation.Models;
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
            EditBookModel obj = new EditBookModel();
            obj.Book = Book.getBook(id);
            obj.Authors = Author.getAuthorList();
            return View(obj);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(string Name, string Pages, string publicationYear, string Information, string ISBN, List<string> authors)
        {
            TempData["title"] = Name;

            TempData["pubYear"] = publicationYear == "" ? 0 : Convert.ToInt32(publicationYear);
            TempData["pages"] = Pages == "" ? 0 : Convert.ToInt16(Pages);
            TempData["info"] = Information == "" ? "" : Information;
            TempData["isbn"] = ISBN;

            List<string> authorsList = new List<string>();
            foreach (var au in authors)
            {
                authorsList.Add(au);
            }
            TempData["authors"] = authorsList;
            return RedirectToAction("Update");
        }

        public RedirectToRouteResult Update()
        {
            List<Author> Authors = new List<Author>();
            foreach(var au in TempData["authors"] as List<string>)
            {
                Authors.Add(new Author
                {
                    Aid = Convert.ToInt32(au)
                });

            }
      
            Book.Update(Convert.ToString(TempData["title"]), Convert.ToString(TempData["isbn"]),
                                        Convert.ToString(TempData["pubYear"]), Convert.ToString(TempData["info"]),
                                        Convert.ToInt16(TempData["pages"]), Authors);
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Add()
        {
            return View(Author.getAuthorList());
        }

        [HttpPost]
        public RedirectToRouteResult Add(Book bookObj)
        {
            return RedirectToAction("Store",bookObj);
        }
        public RedirectToRouteResult Store(Book bookObj)
        {
            Book.Add(bookObj);
            return RedirectToAction("Index", "Books");
        }
    }
}