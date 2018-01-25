using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Mockups
{
    public class AuthorMockup
    {
        static public IEnumerable<Author> GetAuthors()
        {
            return new List<Author>
            {
                new Author {Id = 1, Name = "Astrid Lindgren"},
                new Author {Id = 1, Name = "Astrid Lindgren"},
                new Author {Id = 3, Name = "Hjalmar Olofsson"}
            };
        }
    }
}