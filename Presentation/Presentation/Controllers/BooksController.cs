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
        public ActionResult Index()
        {
            return View(Book.getBookList());
        }
        public ActionResult Info(string id)
        {
            var x = Book.getBook(id);
            return View(x);
        }
        //--------------------------------------------------------EDIT--------------------------------------------------------
        public ActionResult Edit(string id)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

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

            if (authors == null) TempData["authors"] = null;
            else
            {
                List<string> authorsList = new List<string>();
                foreach (var au in authors)
                {
                    authorsList.Add(au);
                }
                TempData["authors"] = authorsList;
            }

            return RedirectToAction("Update");
        }
        public RedirectToRouteResult Update()
        {
            List<Author> Authors = new List<Author>();
            foreach (var au in TempData["authors"] as List<string>)
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
        //--------------------------------------------------------ADD--------------------------------------------------------
        public ActionResult Add()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

            return View(Author.getAuthorList());
        }

        [HttpPost]
        public RedirectToRouteResult Add(Book bookObj, List<int> authorIds)
        {
            if (authorIds != null)
                bookObj.Authors = authorIds.Select(id => new Author { Aid = id }).ToList();

            TempData["book"] = bookObj;

            return RedirectToAction("Store", bookObj);
        }
        public RedirectToRouteResult Store(Book bookObj)
        {
            Book.Add(TempData["book"] as Book);
            return RedirectToAction("Index", "Books");
        }
        [HttpPost]
        //--------------------------------------------------------DELETE--------------------------------------------------------
        public RedirectToRouteResult Delete(string id)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

            var x = Book.getBook(id);
            Book.Delete(x);
            return RedirectToAction("Index", "Books");
        }
    }
}