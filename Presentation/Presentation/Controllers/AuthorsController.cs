﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Models;
using Presentation.Models;

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


        //--------------------------------------------------------EDIT--------------------------------------------------------
        public ActionResult Edit(int id)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

            EditAuthorModel obj = new EditAuthorModel();
            obj.Author = Author.getAuthor(id);
            obj.Books = Book.getBookList();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Edit(string FirstName, string LastName, string BirthYear, string Aid, List<string> books)
        {
            TempData["firstName"] = FirstName;
            TempData["lastName"] = LastName;
            TempData["birthYear"] = BirthYear;
            TempData["aid"] = Convert.ToInt32(Aid);

            if (books == null) TempData["books"] = null;
            else
            {
                List<string> booksList = new List<string>();
                foreach (var bo in books)
                {
                    booksList.Add(bo);
                }
                TempData["books"] = books;
            }

            return RedirectToAction("Update");
        }

        public RedirectToRouteResult Update()
        {
            List<Book> Books = new List<Book>();
            if(TempData["books"] != null)
            {
                foreach (var bo in TempData["books"] as List<string>)
                {
                    Books.Add(new Book
                    {
                        ISBN = bo
                    });
                }
            }
          
            Author.Update(Convert.ToString(TempData["firstName"]), Convert.ToString(TempData["lastName"]),
                                        Convert.ToString(TempData["birthYear"]), Convert.ToInt32(TempData["aid"]),
                                         Books);
            return RedirectToAction("Index", "Authors");
        }

        //--------------------------------------------------------ADD--------------------------------------------------------
        public ActionResult Add()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

            return View(Book.getBookList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Add(Author authorObj, List<string> bookIds)
        {
            if (bookIds != null)
                authorObj.Books = bookIds.Select(id => new Book { ISBN = id }).ToList();

            TempData["author"] = authorObj;

            return RedirectToAction("Store", authorObj);
        }
        public RedirectToRouteResult Store(Author authorObj)
        {
            Author.Add(TempData["author"] as Author);
            return RedirectToAction("Index", "Authors");
        }
        [HttpPost]
        //--------------------------------------------------------DELETE--------------------------------------------------------
        public RedirectToRouteResult Delete(int id)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index");

            var x = Author.getAuthor(id);
            Author.Delete(x);
            return RedirectToAction("Index", "Authors");
        }
    }
}