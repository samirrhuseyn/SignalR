using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.IdentityDtos;

namespace SiqnalRWebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> AdminList()
        {
            var value = await _userManager.Users.ToListAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDto createAdminDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser()
                {
                    Name = createAdminDto.Name,
                    Surname = createAdminDto.Surname,
                    Email = createAdminDto.Mail,
                    UserName = createAdminDto.Username,
                    ImageURL = UploadFile(createAdminDto.ImageURL),
                    PhoneNumber = createAdminDto.Phone
                };
                var result = await _userManager.CreateAsync(appUser, createAdminDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser,"ADMIN");
                    return RedirectToAction("AdminList");
                }
                return View();
            }
            return View(createAdminDto);
        }

        public async Task<IActionResult> DeleteAdmin(string id)
        {
            var value = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(value);
			return RedirectToAction("AdminList");
		}

        private string UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return null;

			var path = Path.Combine(
						Directory.GetCurrentDirectory(), "wwwroot/Image/AdminImages/",
						file.FileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return "/Image/AdminImages/" + file.FileName;
		}
    }
}
