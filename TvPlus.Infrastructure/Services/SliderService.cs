using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.Slider;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Infrastructure.Services
{
    public interface ISliderService : ISliderRepository
    {
        Slider Save(Slider model);
    }
    public class SliderService : SliderRepository, ISliderService
    {
        private readonly ISliderRepository _SliderRepository;
        private readonly MyDbContext _context;
        public SliderService(
            ISliderRepository SliderRepository, MyDbContext context) : base(context)
        {
            _SliderRepository = SliderRepository;
            _context = context;
        }

        public Slider Save(Slider model)
        {
           var savedSlider =  base.AddOrUpdate(model);
           return savedSlider;
        }
    }
}
