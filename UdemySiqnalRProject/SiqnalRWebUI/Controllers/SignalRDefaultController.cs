using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.Controllers
{
	public class SignalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Index2()
        {
            return View();
        }
    }
}
