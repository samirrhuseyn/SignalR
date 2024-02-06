using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
