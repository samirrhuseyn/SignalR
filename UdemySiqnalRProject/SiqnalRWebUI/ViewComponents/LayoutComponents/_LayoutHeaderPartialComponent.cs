using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
