using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface ICategoryService : ICategoryRepository
    {
    }
    public class CategoryService : CategoryRepository, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(
            ICategoryRepository CategoryRepository,MyDbContext context) : base(context)
        {
            _CategoryRepository = CategoryRepository;
        }
    }
}
