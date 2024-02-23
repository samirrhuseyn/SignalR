using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
