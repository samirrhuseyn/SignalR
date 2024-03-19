using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiqnalRWebUI.Models;
using System.Diagnostics;

namespace SiqnalRWebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}