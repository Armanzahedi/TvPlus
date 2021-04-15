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
using TvPlus.Utility.Enums;

namespace TvPlus.Infrastructure.Services
{
    public interface ITagService : ITagRepository
    {
        Tag Save(Tag entity);
        Tag FindByTitle(string search);
    }
    public class TagService : TagRepository, ITagService
    {
        private readonly IMapper _mapper;
        public TagService(
            IMapper mapper,
            MyDbContext context
            ) : base(context)
        {
            _mapper = mapper;
        }

        public Tag Save(Tag entity)
        {
            entity.CenterTypeId = (int)CenterTypes.Tags;
            entity.UniqueId = Guid.NewGuid();
            return base.AddOrUpdate(entity);
        }

        public Tag FindByTitle(string search)
        {
            return base.GetDefaultQuery().FirstOrDefault(t => t.Title != null && t.Title.Trim().ToLower().Equals(search.Trim().ToLower()));
        }
    }
}
