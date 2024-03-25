using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class LoginDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Username")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
    }
}
