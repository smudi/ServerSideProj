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
    }
}