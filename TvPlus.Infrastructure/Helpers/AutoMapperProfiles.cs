using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.Infrastructure.Dtos.ContactUs;
using TvPlus.Infrastructure.Dtos.Post;
using TvPlus.Infrastructure.Dtos.SystemParameter;
using TvPlus.Infrastructure.Dtos.User;

namespace TvPlus.Infrastructure.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // System Parameter
            CreateMap<EditSystemParameterDto, SystemParameter>().ReverseMap();

            // User
            CreateMap<User, UserInfoDto>();
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<UserEditDto, User>().ReverseMap();

            // Contact Us
            CreateMap<EditContactUsDto, ContactUs>().ReverseMap();

            //Post
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<EditPostDto, Post>().ReverseMap();
            CreateMap<PostTagsDto, Tag>().ReverseMap();
            CreateMap<PostPeopleDto, People>().ReverseMap();
        }
    }
}
