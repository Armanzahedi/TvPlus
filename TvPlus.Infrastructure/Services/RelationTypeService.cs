using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface IRelationTypeService : IRelationTypeRepository
    {
        IEnumerable<RelationType> GetDefaultQuery();

    }
    public class RelationTypeService : RelationTypeRepository, IRelationTypeService
    {
        private readonly IRelationTypeRepository _RelationTypeRepository;
        private readonly IMapper _mapper;
        public RelationTypeService(
            IRelationTypeRepository RelationTypeRepository,
            IMapper mapper, MyDbContext context) : base(context)
        {
            _RelationTypeRepository = RelationTypeRepository;
            _mapper = mapper;
        }

        public IEnumerable<RelationType> GetDefaultQuery()
        {
            return _RelationTypeRepository.GetAll();
        }
    }
}
