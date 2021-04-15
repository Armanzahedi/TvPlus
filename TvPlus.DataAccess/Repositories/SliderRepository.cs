using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
    }
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        private readonly MyDbContext _context;
        public SliderRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
