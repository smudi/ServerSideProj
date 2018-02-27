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
                return db.BOOKs.Include(x => x.AUTHORs).ToList().Find(d => d.ISBN == id);
                //db.BOOKs.Where(b => b.ISBN == id).FirstOrDefault(); 
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

        public void Update(BOOK bookObj)
        {
            using (var db = new LibDb())
            {

                var b = db.BOOKs.Include(x => x.AUTHORs).ToList().Find(d => d.ISBN ==
                bookObj.ISBN);
                b.AUTHORs.Clear();

                db.SaveChanges();
            }

            var newAuthors = bookObj.AUTHORs;
            bookObj.AUTHORs = new List<AUTHOR>();

            using (var db = new LibDb())
            {

                db.BOOKs.Attach(bookObj);
                db.Entry(bookObj).State = EntityState.Modified;

                foreach (var author in newAuthors)
                {
                    db.AUTHORs.Attach(author);
                    bookObj.AUTHORs.Add(author);
                }

                db.SaveChanges();
    }
        }

        public void Add(BOOK bookObj)
        {
            using (var db = new LibDb())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BOOKs.Load();
                        db.BOOKs.Add(bookObj);  // Prepare query
                        db.SaveChanges();         // Run the query
                        transaction.Commit();   //  Permanent the result, writing to disc and closing transaction
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();  //Undo all changes if exception is thrown
                    }
                }
            }
        }

    }
}