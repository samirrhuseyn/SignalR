using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _HomeOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
