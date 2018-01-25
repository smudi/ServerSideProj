using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Author Author { get; set; }
        public String Information { get; set; }
    }
}