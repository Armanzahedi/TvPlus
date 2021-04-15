using System;
using System.Collections.Generic;
using System.Linq;
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
    public interface IMemberService : IMemberRepository
    {
        Member Save(Member entity);
    }
    public class MemberService : MemberRepository, IMemberService
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MemberService(
            IMapper mapper,
            MyDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public Member Save(Member entity)
        {
            var a = base.GetById(entity.Id);

            if (a != null)
                base.Update(entity);
            else
                base.Add(entity);

            return entity;
        }
    }
}
