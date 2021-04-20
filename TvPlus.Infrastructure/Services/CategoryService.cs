using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using TvPlus.Infrastructure.Dtos.Category;

namespace TvPlus.Infrastructure.Services
{
    public interface ICategoryService : ICategoryRepository
    {
        Category Save(EditCategoryViewModel model);
        EditCategoryViewModel GetCategoryForEdit(int id);
        Task<List<CategoryViewModel>> GetMainMenuItemsAsync();
    }
    public class CategoryService : CategoryRepository, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IImageService _imageService;
        private readonly MyDbContext _context;

        public CategoryService(ICategoryRepository CategoryRepository, IImageService imageService, MyDbContext context) : base(context)
        {
            _CategoryRepository = CategoryRepository;
            _imageService = imageService;
            _context = context;
        }

        public Category Save(EditCategoryViewModel model)
        {
            var Category = new Category
            {
                Id = model.Id,
                Title = model.Title,
                ParentId = model.ParentId,
                Show = model.Show,
            };
            var savedCategory = base.AddOrUpdate(Category);
            return savedCategory;
        }


        public EditCategoryViewModel GetCategoryForEdit(int id)
        {
            var category = base.GetById(id);
            //var image = _imageService.GetByCenterId(id);
            var vm = new EditCategoryViewModel
            {
                Id = category.Id,
                Title = category.Title
            };

            return vm;
        }


        public async Task<List<CategoryViewModel>> GetMainMenuItemsAsync()
        {
            return await _context.Categories
                        .Where(w => w.Show && w.IsDeleted == false)
                        .Select(s => new CategoryViewModel { Id = s.Id, ParentId = s.ParentId, Show = s.Show, Title = s.Title })
                        .ToListAsync();
        }
    }
}
