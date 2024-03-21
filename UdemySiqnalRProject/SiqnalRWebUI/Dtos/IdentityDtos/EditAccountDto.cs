using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.IdentityDtos
{
    public class EditAccountDto
    {
        [Key]
        public string? Name { get; set; }
        public string? Surname { get; set; }      
        public string? Username { get; set; }
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePreview { get; set; }
        public string? Phone { get; set; }
    }
}
