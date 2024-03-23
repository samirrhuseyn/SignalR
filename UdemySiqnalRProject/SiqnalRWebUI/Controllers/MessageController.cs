using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult ChatList()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
