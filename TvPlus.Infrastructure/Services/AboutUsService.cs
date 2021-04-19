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
        AboutUs GetAboutUs();
        List<AboutUsSection> GetAboutUsSections();
        AboutUsSection GetSectionById(int id);
        AboutUsSection UpdateSection(AboutUsSection model);
    }
    public class AboutUsService : AboutUsRepository, IAboutUsService
    {
        private readonly IAboutUsSectionsRepository _AboutUsSectionRepository;
        private readonly MyDbContext _context;
        public AboutUsService(MyDbContext context, IAboutUsSectionsRepository aboutUsSectionRepository) : base(context)
        {
            _context = context;
            _AboutUsSectionRepository = aboutUsSectionRepository;
        }
        public AboutUs GetAboutUs()
        {
            return _context.AboutUs.FirstOrDefault();
        }

        public List<AboutUsSection> GetAboutUsSections()
        {
            return _context
                .AboutUsSections.ToList();
        }
        public AboutUsSection GetSectionById(int id)
        {
            return _context.AboutUsSections.Find(id);
        }

        public AboutUsSection UpdateSection(AboutUsSection model)
        {
            return _AboutUsSectionRepository.Update(model);
        }
    }
}
