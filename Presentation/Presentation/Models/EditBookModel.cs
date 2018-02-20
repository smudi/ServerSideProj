using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Presentation.Models
{
    public class EditBookModel
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
    }
}