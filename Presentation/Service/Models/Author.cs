using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Repository.Support;
using AutoMapper;

namespace Service.Models
{
    public class Author
    {
        public int Aid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthYear { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        static private EAuthor _eAuthorObj = new EAuthor();

        static public Author getAuthor(int id)
        {
            AUTHOR authorObj = _eAuthorObj.Find(id); // go to EAuthor in repository, get the author from the database
            Author author = Mapper.Map<Author>(authorObj); // save author as Author object in Service
            author.FirstName = author.FirstName.Trim();
            author.LastName = author.LastName.Trim();
            author.Books = Mapper.Map<List<BOOK>, List<Book>>(authorObj.BOOKs.ToList());
            return author;
        }
        static public List<Author> getAuthorList()
        {
            return Mapper.Map<List<AUTHOR>, List<Author>>(_eAuthorObj.List());
        }

        static public void Update(string _FirstName, string _LastName, string _BirthYear, int _Aid, List<Book> list)
        {
            Author authorObj = Author.getAuthor(_Aid);

            authorObj.FirstName = _FirstName;
            authorObj.LastName = _LastName;
            authorObj.BirthYear = _BirthYear;
            authorObj.Aid = _Aid;

            authorObj.Books = list;

            _eAuthorObj.Update(Mapper.Map<AUTHOR>(authorObj));
        }
    }
}