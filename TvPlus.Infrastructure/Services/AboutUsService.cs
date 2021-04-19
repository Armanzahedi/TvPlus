using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface IAboutUsService : IAboutUsRepository
    {
    }
    public class AboutUsService : AboutUsRepository, IAboutUsService
    {
        private readonly IAboutUsRepository _AboutUsRepository;
        public AboutUsService(
            IAboutUsRepository AboutUsRepository,MyDbContext context) : base(context)
        {
            _AboutUsRepository = AboutUsRepository;
        }
    }
}
