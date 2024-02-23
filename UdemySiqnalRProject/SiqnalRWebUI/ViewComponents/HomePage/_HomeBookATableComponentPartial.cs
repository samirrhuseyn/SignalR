using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _HomeBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
