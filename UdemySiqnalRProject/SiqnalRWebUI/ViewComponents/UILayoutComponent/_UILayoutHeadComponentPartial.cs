using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
