using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Utility.Enums;
using Xabe.FFmpeg;

namespace TvPlus.Infrastructure.Services
{
    public interface ICenterService : ICenterRepository
    {
        Center Save(Center entity);
        List<Category> GetCenterCategories(int centerId);
        List<CenterCategory> SaveCenterCategories(int centerId, List<int> categoryIds);
        void DeleteCenterCategories(int centerId);
    }

    public class CenterService : CenterRepository, ICenterService
    {
        private readonly IVideoRepository _videoRepo;
        private readonly ICenterCategoryRepository _centerCategoryRepo;
        private readonly MyDbContext _context;

        public CenterService(
            MyDbContext context, IVideoRepository videoRepo,
            ICenterCategoryRepository centerCategoryRepo) : base(context)
        {
            _context = context;
            _videoRepo = videoRepo;
            _centerCategoryRepo = centerCategoryRepo;
        }

        public Center Save(Center entity)
        {
            return base.AddOrUpdate(entity);
        }

        public List<Category> GetCenterCategories(int centerId)
        {
            return _context.CenterCategories.Where(cc => cc.IsDeleted == false && cc.CenterId == centerId)
                .Select(cc => cc.Category).ToList();
        }

        public List<CenterCategory> SaveCenterCategories(int centerId, List<int> categoryIds)
        {
            var result = new List<CenterCategory>();
            DeleteCenterCategories(centerId);
            foreach (var id in categoryIds)
            {
                var centerCategory = new CenterCategory
                {
                    CategoryId = id,
                    CenterId = centerId,
                    IsDeleted = false,
                };
                var savedItem = _centerCategoryRepo.AddOrUpdate(centerCategory);
                result.Add(savedItem);
            }

            return result;
        }

        public void DeleteCenterCategories(int centerId)
        {
            var prevCenterCategories = _centerCategoryRepo.GetDefaultQuery()
                .Where(cc => cc.IsDeleted == false && cc.CenterId == centerId).ToList();
            foreach (var item in prevCenterCategories)
            {
                _centerCategoryRepo.Delete(item);
            }

        }
    }
}