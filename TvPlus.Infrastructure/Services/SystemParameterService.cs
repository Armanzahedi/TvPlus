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
using TvPlus.Infrastructure.Dtos.SystemParameter;

namespace TvPlus.Infrastructure.Services
{
    public interface ISystemParameterService : ISystemParameterRepository
    {
        SystemParameter Save(EditSystemParameterDto model);
    }
    public class SystemParameterService : SystemParameterRepository, ISystemParameterService
    {
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly IMapper _mapper;
        public SystemParameterService(
            ISystemParameterRepository systemParameterRepository,
            IMapper mapper, MyDbContext context) : base(context)
        {
            _systemParameterRepository = systemParameterRepository;
            _mapper = mapper;
        }
        public SystemParameter Save(EditSystemParameterDto model)
        {
            var entity = _mapper.Map<SystemParameter>(model);
            return base.AddOrUpdate(entity);
        }
    }
}
