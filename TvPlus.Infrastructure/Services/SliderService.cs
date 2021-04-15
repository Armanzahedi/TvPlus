using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.Slider;

namespace TvPlus.Infrastructure.Services
{
    public interface ISliderService : ISliderRepository
    {
        Slider Add(EditSliderDto model);
        Slider Update(EditSliderDto model, int id);
    }
    public class SliderService : SliderRepository, ISliderService
    {
        private readonly ISliderRepository _SliderRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        public SliderService(
            ISliderRepository SliderRepository,
            IMapper mapper,MyDbContext context) : base(context)
        {
            _SliderRepository = SliderRepository;
            _mapper = mapper;
        }

        public Slider Add(EditSliderDto model)
        {
            var entity = new Slider { InsertDate = DateTime.Now };
            entity = _mapper.Map<Slider>(model);
            return base.AddOrUpdate(entity);
        }
        public Slider Update(EditSliderDto model, int id)
        {
            var entity = _mapper.Map<Slider>(model);
            var oldEntity = base.GetById(id);
            entity.InsertDate = oldEntity.InsertDate;
            entity.InsertUser = oldEntity.InsertUser;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
            entity.UpdateDate = DateTime.Now;
            entity.Id = id;
            return base.AddOrUpdate(entity);
        }
    }
}
