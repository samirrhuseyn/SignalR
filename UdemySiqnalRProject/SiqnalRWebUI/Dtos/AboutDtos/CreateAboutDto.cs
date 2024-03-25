using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        [Required, DataType(DataType.ImageUrl), Display(Name ="Image")]
        public string ImageURL { get; set; }
        [Required, DataType(DataType.ImageUrl), Display(Name = "Title")]
        public string Title { get; set; }
        [Required, DataType(DataType.ImageUrl), Display(Name = "Description")]
        public string Description { get; set; }
    }
}
