using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Services.Membership;

namespace TvPlus.Infrastructure.Services
{
    public interface IPeopleService : IPeopleRepository
    {
        People Save(People entity);
        People FindByFirstAndLastName(string search);
    }
    public class PeopleService : PeopleRepository, IPeopleService
    {
        private readonly IMapper _mapper;
        //private readonly IMembershipManagementBaseService _membershipManagementService;
        public PeopleService(
            IMapper mapper, MyDbContext context) : base(context)
        {
            _mapper = mapper;
            //_membershipManagementService = membershipManagementService;
        }


        public People Save(People entity)
        {

            var a = base.GetById(entity.Id);

            //save tags
            


            //save persons

            //save specials






            if (a != null)
                base.Update(entity);
            else
                base.Add(entity);

            return entity;
        }

        public People FindByFirstAndLastName(string search)
        {
            return base.GetDefaultQuery().FirstOrDefault(p =>
                p.Firstname != null && p.Lastname != null &&
                $"{p.Firstname} {p.Lastname}".Trim().ToLower().Equals(search.Trim().ToLower()));
        }
    }
}
