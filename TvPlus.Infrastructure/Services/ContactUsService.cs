using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.ContactUs;

namespace TvPlus.Infrastructure.Services
{
    public interface IContactUsService : IContactUsRepository
    {
        ContactUs Add(EditContactUsDto model);
        ContactUs Update(EditContactUsDto model);
    }

    public class ContactUsService : ContactUsRepository, IContactUsService
    {
        private readonly IMapper _mapper;

        public ContactUsService(
            IMapper mapper, MyDbContext context) : base(context)
        {
            _mapper = mapper;
        }

        public ContactUs Add(EditContactUsDto model)
        {
            var entity = _mapper.Map<ContactUs>(model);
            base.Add(entity);
            return entity;
        }

        public ContactUs Update(EditContactUsDto model)
        {
            var contactUs = GetFirst();
            var entity = _mapper.Map<ContactUs>(model);
            entity.Id = contactUs.Id;
            base.Update(entity);
            return entity;
        }
    }
}