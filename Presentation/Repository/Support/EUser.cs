using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;

namespace Repository.Support
{
    public class EUser
    {
        private USER _user = null;
        public USER User { get { return _user; } }
        public EUser() { }

        public EUser(int id)
        {
            _user = this.Find(id);
        }
        public USER Find(int id)  //Finds a particular user
        {
            using (var db = new LibDb())
            {
                return db.USERs.Where(b => b.UserId == id).FirstOrDefault(); 
            }
        }
        public List<USER> List()  //Retrieves all books
        {
            using (var db = new LibDb())
            {
                var query = db.USERs.OrderBy(x => x.UserName);
                return query.ToList();
            }
        }
        public List<USER> adminList()  //Retrieves all books
        {
            using (var db = new LibDb())
            {
                var query = db.USERs.Where(x => x.UserRank == 1);
                return query.ToList();
            }
        }
        public void Add(USER user)
        {
            using (var db = new LibDb())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.USERs.Add(user);  // Prepare query
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
        public USER FindByName(string name)
        {
            using (var db = new LibDb())
            {
                return db.USERs.Where(b => b.UserName == name).FirstOrDefault();
            }
        }
        public void Update(USER user)
        {

            using (var db = new LibDb())
            {
                db.USERs.Attach(user);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}