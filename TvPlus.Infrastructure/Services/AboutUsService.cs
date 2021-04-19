using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface IAboutUsService : IAboutUsRepository
    {
        AboutUs GetAboutUsWithSectionNavigation();
    }
    public class AboutUsService : AboutUsRepository, IAboutUsService
    {
        private readonly IAboutUsRepository _AboutUsRepository;
        private readonly MyDbContext _context;
        public AboutUsService(
            IAboutUsRepository AboutUsRepository,MyDbContext context) : base(context)
        {
            _AboutUsRepository = AboutUsRepository;
            _context = context;
        }

        public AboutUs GetAboutUsWithSectionNavigation()
        {
            return _context.AboutUs.Include(a => a.AboutUsSections).FirstOrDefault();
        }
    }
}
