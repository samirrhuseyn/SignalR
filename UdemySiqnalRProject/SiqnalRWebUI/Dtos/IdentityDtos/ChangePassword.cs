using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class ChangePassword
    {
        public string UserId { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "CurrentPassword")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "NewPassword")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match!")]
        [Required, DataType(DataType.Password), Display(Name = "ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
