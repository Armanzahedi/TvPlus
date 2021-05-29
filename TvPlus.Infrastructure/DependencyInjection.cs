using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TvPlus.Core.Models;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Services.Membership;

namespace TvPlus.Infrastructure
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region Add Services
            //services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ISystemParameterService, SystemParameterService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<ICenterService, CenterService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IRelationTypeService, RelationTypeService>();
            services.AddScoped<IRelationRuleService, RelationRuleService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICenterService, CenterService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IMembershipManagementBaseService, MembershipManagementBaseService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IContactUsInfoService, ContactUsInfoService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ISubscriptionPackageService, SubscriptionPackageService>();
            services.AddScoped<IDiscountService, DiscountService>();

            #endregion

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
