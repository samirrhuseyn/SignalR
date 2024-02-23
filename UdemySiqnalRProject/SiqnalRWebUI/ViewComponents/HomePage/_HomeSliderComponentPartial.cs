using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _HomeSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
