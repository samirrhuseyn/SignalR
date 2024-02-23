using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
