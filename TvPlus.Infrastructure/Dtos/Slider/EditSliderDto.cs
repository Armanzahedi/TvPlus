using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TvPlus.Infrastructure.Dtos.Slider
{
    public class EditSliderDto
    {
        public int PostId { get; set; }
        public IFormFile Image { get; set; }
    }
}
