using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        [Required, DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageURL { get; set; }
        [Required, DataType(DataType.ImageUrl), Display(Name = "Title")]
        public string Title { get; set; }
        [Required, DataType(DataType.ImageUrl), Display(Name = "Description")]
        public string Description { get; set; }
    }
}
