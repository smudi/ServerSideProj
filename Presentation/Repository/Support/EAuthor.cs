using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;

namespace Repository.Support
{
    public class EAuthor
    {
        private AUTHOR _authorObj = null;
        public AUTHOR AuthorObj { get { return _authorObj; } }
        public EAuthor() { }

        public EAuthor(int id)
        {
            _authorObj = this.Find(id);
        }
        public AUTHOR Find(int id)  //Finds a particular author
        {
            using (var db = new LibDb())
            {
                return db.AUTHORs.Include(x => x.BOOKs).ToList().Find(d => d.Aid == id);
            }
        }
        public List<AUTHOR> List()  //Retrieves all authors
        {
            using (var db = new LibDb())
            {
                var query = db.AUTHORs.OrderBy(x => x.LastName);
                return query.ToList();
            }
        }

        public void Update(AUTHOR authorObj)
        {
            using (var db = new LibDb())
            {

                var b = db.AUTHORs.Include(x => x.BOOKs).ToList().Find(d => d.Aid ==
                authorObj.Aid);
                b.BOOKs.Clear();

                db.SaveChanges();
            }

            var newBooks = authorObj.BOOKs;
            authorObj.BOOKs = new List<BOOK>();

            using (var db = new LibDb())
            {

                db.AUTHORs.Attach(authorObj);
                db.Entry(authorObj).State = EntityState.Modified;

                foreach (var book in newBooks)
                {
                    db.BOOKs.Attach(book);
                    authorObj.BOOKs.Add(book);
                }

                db.SaveChanges();
            }
        }
        public void Add(AUTHOR author)
        {
            using (var db = new LibDb())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var bo in author.BOOKs)
                        {
                            db.BOOKs.Attach(bo);
                        }
         
                        db.AUTHORs.Add(author);  // Prepare query
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
        public void Delete(AUTHOR author)
        {
            using (var db = new LibDb())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    db.AUTHORs.Attach(author);
                    foreach (var bo in author.BOOKs)
                    {
                        db.BOOKs.Attach(bo);
                    }
                    try
                    {
                        author.BOOKs.Clear();
                        db.AUTHORs.Remove(author);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

        }
    }
}