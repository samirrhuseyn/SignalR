using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;

namespace SiqnalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutProfileImageNavbarPartialComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public _LayoutProfileImageNavbarPartialComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			return View(value);
		}
	}
}
