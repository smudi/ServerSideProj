using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public String Name { get; set; }
    }
}