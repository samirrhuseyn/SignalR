using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.IdentityDtos;

namespace SiqnalRWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginDto.Username);
                var isConfirmMail = await _userManager.IsEmailConfirmedAsync(user);
                if (isConfirmMail)
                {
                    var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Statistic");
                    }
                    ModelState.AddModelError("Password", "Wrong Password!");
                }
                else return RedirectToAction("NotConfirm");
            }
            return View(loginDto);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        public IActionResult NotConfirm()
        {
            return View();
        }
    }
}
