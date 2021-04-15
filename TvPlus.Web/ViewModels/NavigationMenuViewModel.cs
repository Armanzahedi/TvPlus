using System;

namespace TvPlus.Web.ViewModels
{
	public class NavigationMenuViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int? ParentMenuId { get; set; }
		public string Icon { get; set; }
		public string ElementIdentifier { get; set; }

		public string Area { get; set; }

		public string ControllerName { get; set; }

		public string ActionName { get; set; }

		public bool Permitted { get; set; }

		public int DisplayOrder { get; set; }

		public bool Visible { get; set; }
	}
}