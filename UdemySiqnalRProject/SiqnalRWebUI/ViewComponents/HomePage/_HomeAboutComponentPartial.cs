using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _HomeAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
