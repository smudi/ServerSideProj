using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Repository.Support;
using AutoMapper;

namespace Service.Models
{
    public class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public int? SignId { get; set; }

        public string PublicationYear { get; set; }

        public string publicationinfo { get; set; }

        public short? pages { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        static private EBook _eBookObj = new EBook();

        static public Book getBook(string id)
        {
            BOOK bookObj = _eBookObj.Find(id); // go to EBook in repository, get the book from the database
            Book book = Mapper.Map<Book>(bookObj); // save book as Book object in Service
            book.Title = book.Title;
            book.Authors = Mapper.Map<List<AUTHOR>, List<Author>>(bookObj.AUTHORs.ToList()); 
            return book;
        }
        static public List<Book> getBookList()
        {
            return Mapper.Map<List<BOOK>, List<Book>>(_eBookObj.List());
        }

        static public void Update(string _Title, string _ISBN, string _PubYear, string _PubInfo, short _Pages, List<Author> list)
        {
            Book bookObj = Book.getBook(_ISBN);

            bookObj.Title = _Title;
            bookObj.PublicationYear = _PubYear;
            bookObj.publicationinfo = _PubInfo;
            bookObj.pages = _Pages;

            bookObj.Authors = list;

            _eBookObj.Update(Mapper.Map<BOOK>(bookObj));
        }

        static public void Add(Book bookObj)
        {
            _eBookObj.Add(Mapper.Map<BOOK>(bookObj));
        }
    }
}