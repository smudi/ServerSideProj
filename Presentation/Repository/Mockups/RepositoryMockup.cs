using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Repository.Mockups
{
    public class RepositoryMockup
    {
        private List<Book> bookList;
        private List<Author> authorList;
        private List<Administrator> adminList;
        public RepositoryMockup()
        {
            bookList = new List<Book>
            {
                new Book {Id = 1, Name = "Pippi Långstrump", Information = "Is a very popular childrens book"},
                new Book {Id = 2, Name = "Ronja Rövardotter", Information = "Was written in Sweden"},
                new Book {Id = 3, Name = "Frankenstein", Information ="Book was written 1894"}
            };

            authorList = new List<Author>
            {
                new Author {Id = 1, Name = "Astrid Lindgren", Information="She lived in Kalmar"},
                new Author {Id = 3, Name = "Hjalmar Olofsson", Information="He died 1950 at the age of 90"}
            };

            adminList = new List<Administrator>
            {
                new Administrator {Id=1, Name="Ebba Svensson", Information = "Programmer"},
                new Administrator {Id=2, Name = "Carolina Carlbom", Information ="Designer"}
            };

        }
        public List<Book> BookList { get { return bookList; } set { bookList = value; } }
        public List<Author> AuthorList { get { return authorList; } set { authorList = value; } }
        public List<Administrator> AdminList { get { return adminList; } set { adminList = value; } }
    }
}