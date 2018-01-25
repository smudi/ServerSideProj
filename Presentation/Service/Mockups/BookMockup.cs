using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Mockups
{
    public class BookMockup
    {
        static public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Id = 1, Name = "Pippi Långstrump", Information = "Is a very popular childrens book"},
                new Book {Id = 2, Name = "Ronja Rövardotter", Information = "Was written in Sweden"},
                new Book {Id = 3, Name = "Frankenstein", Information ="Book was written 1894"}
            };
        }
    }
}