using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Service.Models;
using Repository;

namespace Service.Configuration
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ToBookProfile());
                cfg.AddProfile(new FromBookProfile());

                cfg.AddProfile(new ToAuthorProfile());
                cfg.AddProfile(new FromAuthorProfile());

                cfg.AddProfile(new ToUserProfile());
                cfg.AddProfile(new FromUserProfile());
            });
        }
        public class ToBookProfile : Profile
        {
            public ToBookProfile()
            {
                CreateMap<BOOK, Book>().ForMember(m => m.Authors, opt => opt.Ignore());
            }
        }
        public class FromBookProfile : Profile
        {
            public FromBookProfile()
            {
                CreateMap<Book, BOOK>();
            }
        }

        public class ToAuthorProfile : Profile
        {
            public ToAuthorProfile()
            {
                CreateMap<AUTHOR, Author>().ForMember(m => m.Books, opt => opt.Ignore());
            }
        }
        public class FromAuthorProfile : Profile
        {
            public FromAuthorProfile()
            {
                CreateMap<Author, AUTHOR>();
            }
        }
        public class ToUserProfile : Profile
        {
            public ToUserProfile()
            {
                CreateMap<User, USER>();
            }
        }
        public class FromUserProfile : Profile
        {
            public FromUserProfile()
            {
                CreateMap<USER, User>();
            }
        }
    }
}