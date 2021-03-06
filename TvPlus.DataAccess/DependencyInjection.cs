using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.DataAccess
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            #region Add Repositories

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISystemParameterRepository, SystemParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IRelationTypeRepository, RelationTypeRepository>();
            services.AddScoped<IRelationRuleRepository, RelationRuleRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IVideoConvertRepository, VideoConvertRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICenterCategoryRepository, CenterCategoryRepository>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IAboutUsSectionsRepository, AboutUsSectionsRepository>();
            services.AddScoped<IContactUsInfoRepository, ContactUsInfoRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ISubscriptionPackageRepository, SubscriptionPackageRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();


            #endregion

            return services;
        }
    }
}
