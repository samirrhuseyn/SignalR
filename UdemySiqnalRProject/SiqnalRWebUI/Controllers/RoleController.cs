using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.IdentityDtos;
using System.Data;

namespace SiqnalRWebUI.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = _roleManager.Roles.ToList();
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserID"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssign = new RoleAssignViewModel();
                roleAssign.RoleID = item.Id;
                roleAssign.RoleName = item.Name;
                roleAssign.Exists = userRoles.Contains(item.Name);
                model.Add(roleAssign);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var UserId = TempData["UserID"];

            string UserString = new Guid(UserId.ToString()).ToString();
            var user = _userManager.Users.FirstOrDefault(x => x.Id == UserString);
            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("AdminList", "Admin");
        }
    }
}
