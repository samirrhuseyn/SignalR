using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.IdentityDtos;

namespace SiqnalRWebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        MailManager mailManager = new MailManager();

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AdminList()
        {
            var value = await _userManager.Users.ToListAsync();
            return View(value);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
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
                    await _userManager.AddToRoleAsync(appUser,"JUNIOR");
                    var confirmCode = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var confirmUrl = Url.Action("ConfirmEmail", new {userId = appUser.Id, confirmdCode = confirmCode});
                    var body = "http://localhost:5047" + confirmUrl;
                    mailManager.SendMail(appUser.Email, body, "Email Confirmation");
                    return RedirectToAction("AdminList");
                }
                return View();
            }
            return View(createAdminDto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string confirmdCode)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(confirmdCode))
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.ConfirmEmailAsync(user, confirmdCode);
                    if (result.Succeeded)
                        return RedirectToAction("ConfirmSuccess");

                    else
                        return RedirectToAction("ConfirmError");
                }
                else
                    return RedirectToAction("NotUser");
            }
            return RedirectToAction("ErrorUrl");
        }

        [HttpGet]
        public async Task<IActionResult> EditAccount()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var account = new EditAccountDto
            {
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Username = values.UserName,
                Phone = values.PhoneNumber,
                ImagePreview = values.ImageURL
            };
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(EditAccountDto editAccount)
        {
            if (ModelState.IsValid)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.Name = editAccount.Name;
                values.Surname = editAccount.Surname;
                values.Email = editAccount.Email;
                values.UserName = editAccount.Username;
                values.PhoneNumber = editAccount.Phone;
                values.ImageURL = editAccount.Image != null ? UploadFile(editAccount.Image) : values.ImageURL;
                await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Statistic");
            }
            return View(editAccount);
        }
        [Authorize(Roles = "Admin,Manager")]
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordCode = await _userManager.GeneratePasswordResetTokenAsync(user);
                var returnUrl = Url.Action("UpdatePassword", new { userId = user.Id, passwordCode });
                var body = "http://localhost:5047" + returnUrl;
                mailManager.SendMail(model.Email, body, subject: "Reset Link");
                return RedirectToAction("LinkSuccess");
            }
            return RedirectToAction("EmailNotFound");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UpdatePassword(string userId, string passwordCode)
        {
            if (userId != null && passwordCode != null)
            {
                var passwordDto = new ForgotPasswordDto();
                passwordDto.UserId = userId;
                passwordDto.PasswordCode = passwordCode;
                return View(passwordDto);
            }
            return RedirectToAction("EmailNotFound");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.NewPassword != null)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                var result = await _userManager.ResetPasswordAsync(user, model.PasswordCode, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction("UpdateSuccess");
            }
            return RedirectToAction("UpdateFailed");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = user.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            if (!ModelState.IsValid)
                return View(changePassword);
            var user = await _userManager.FindByIdAsync(changePassword.UserId);
            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, changePassword.CurrentPassword, false);
            if (checkPassword.Succeeded) 
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePassword.NewPassword);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
					return RedirectToAction("UpdatePasswordSuccess");
				}    
                
            }
            return RedirectToAction("UpdatePasswordError");
        }

        [AllowAnonymous]
        public IActionResult ConfirmSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ConfirmError()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NotUser()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ErrorUrl()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult LinkSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult EmailNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdateSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdateFailed()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdatePasswordSuccess()
        {
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult UpdatePasswordError()
        {
            return View();
        }
    }
}
