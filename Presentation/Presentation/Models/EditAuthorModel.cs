using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Presentation.Models
{
    public class EditAuthorModel
    {
        public Author Author { get; set; }
        public List<Book> Books { get; set; }
    }
}