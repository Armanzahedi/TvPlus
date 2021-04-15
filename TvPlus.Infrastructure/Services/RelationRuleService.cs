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

namespace TvPlus.Infrastructure.Services
{
    public interface IRelationRuleService : IRelationRuleRepository
    {
        new IEnumerable<RelationRule> GetDefaultQuery();
    }
    public class RelationRuleService : RelationRuleRepository, IRelationRuleService
    {
        private readonly IRelationRuleRepository _RelationRuleRepository;
        private readonly IMapper _mapper;
        public RelationRuleService(
            IRelationRuleRepository RelationRuleRepository,
            IMapper mapper, MyDbContext context) : base(context)
        {
            _RelationRuleRepository = RelationRuleRepository;
            _mapper = mapper;
        }
        
        public new IEnumerable<RelationRule> GetDefaultQuery()
        {
            return _RelationRuleRepository.GetAll();
        }
    }
}
