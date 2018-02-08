using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;

namespace Repository.Support
{
    public class EBook
    {
        private BOOK _bookObj = null;
        public BOOK BookObj { get { return _bookObj; } }
        public EBook() { }

        public EBook(string ISBN)
        {
            _bookObj = this.Find(ISBN);
        }
        public BOOK Find(string id)  //Finds a particular book
        {
            using (var db = new LibDb())
            {
                return db.BOOKs.Where(b => b.ISBN == id).FirstOrDefault(); 
            }
        }
        public List<BOOK> List()  //Retrieves all books
        {
            using (var db = new LibDb())
            {
                var query = db.BOOKs.OrderBy(x => x.Title);
                return query.ToList();
            }
        }
    }
}