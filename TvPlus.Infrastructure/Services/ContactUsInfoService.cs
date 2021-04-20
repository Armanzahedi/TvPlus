using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.ContactUsInfo;

namespace TvPlus.Infrastructure.Services
{
    public interface IContactUsInfoService : IContactUsInfoRepository
    {
        ContactUsInfo Save(EditContactUsInfoDto model);
    }
    public class ContactUsInfoService : ContactUsInfoRepository, IContactUsInfoService
    {
        private readonly IContactUsInfoRepository _ContactUsInfoRepository;
        private readonly IMapper _mapper;
        public ContactUsInfoService(
            IContactUsInfoRepository ContactUsInfoRepository,
            IMapper mapper, MyDbContext context) : base(context)
        {
            _ContactUsInfoRepository = ContactUsInfoRepository;
            _mapper = mapper;
        }
        public ContactUsInfo Save(EditContactUsInfoDto model)
        {
            var entity = _mapper.Map<ContactUsInfo>(model);
            return base.AddOrUpdate(entity);
        }

    }
}
