using System.ComponentModel.DataAnnotations;

namespace TvPlus.Web.ViewModels
{
	public class RoleViewModel
	{
		public string Id { get; set; }
		[Display(Name= "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Name { get; set; }

		public bool Selected { get; set; }
	}
}