using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Infrastructure.Services
{
    public interface ICategoryService : ICategoryRepository
    {
        Category Save(EditCategoryViewModel model);
        EditCategoryViewModel GetCategoryForEdit(int id);
    }
    public class CategoryService : CategoryRepository, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IImageService _imageService;

        public CategoryService(ICategoryRepository CategoryRepository, IImageService imageService, MyDbContext context) : base(context)
        {
            _CategoryRepository = CategoryRepository;
            _imageService = imageService;
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
    }
}
