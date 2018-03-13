using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Repository.Support;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Service.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string HashPassWord { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassWord { get; set; }

        public int UserRank { get; set; }

        
        static private EUser _eUser = new EUser();

        static public User getUser(int id)
        {
            USER tempUser = _eUser.Find(id); // go to EBook in repository, get the book from the database
            User user = Mapper.Map<User>(tempUser); // save book as Book object in Service
            return user;
        }
        static public List<User> getUserList()
        {
            return Mapper.Map<List<USER>, List<User>>(_eUser.List());
        }
        static public void Add(User user)
        {
            _eUser.Add(Mapper.Map<USER>(user));
        }

        static public User getUserByName(string name)
        {
            USER tempUser = _eUser.FindByName(name);
            User user = Mapper.Map<User>(tempUser);
            return user;
        }
    }
}