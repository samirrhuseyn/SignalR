using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class ForgotPasswordDto
    {
        public string? UserId { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please Enter New Password")]
        public string? NewPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? RePassword { get; set; }

        public string? PasswordCode { get; set; }
        public string? Email { get; set; }
    }
}
