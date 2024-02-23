using Microsoft.AspNetCore.Mvc;
using SiqnalRWebUI.Models;
using System.Diagnostics;

namespace SiqnalRWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}