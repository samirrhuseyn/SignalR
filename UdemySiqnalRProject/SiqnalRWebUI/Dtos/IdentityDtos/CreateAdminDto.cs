using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class CreateAdminDto
    {
        
        public IFormFile ImageURL { get; set; }

        [MaxLength(15, ErrorMessage = "Name cannot be more than 15 characters!")]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2 characters!")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Surname cannot be more than 20 characters!")]
        [MinLength(2, ErrorMessage = "Surname cannot be less than 2 characters!")]
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
