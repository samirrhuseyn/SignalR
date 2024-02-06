using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
