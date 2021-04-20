using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Components
{
	public class SliderViewComponent : ViewComponent
	{
		private readonly ISliderService _sliderService;

		public SliderViewComponent(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _sliderService.GetSlidersAsync();

			return View(items);
		}
	}
}
