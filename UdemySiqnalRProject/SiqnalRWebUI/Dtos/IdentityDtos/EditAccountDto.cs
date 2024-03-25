using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class EditAccountDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string? Name { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Surname")]
        public string? Surname { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Username")]
        public string? Username { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string? Email { get; set; }

        [Required, DataType(DataType.Upload), Display(Name = "Image")]
        public IFormFile? Image { get; set; }
        public string? ImagePreview { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone")]
        public string? Phone { get; set; }
    }
}
