using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
