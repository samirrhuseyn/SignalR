using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.Message
{
    public class _ChatListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
