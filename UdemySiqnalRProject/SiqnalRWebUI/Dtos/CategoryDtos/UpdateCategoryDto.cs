using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.CategoryDtos
{
	public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string CategoryName { get; set; }
		public bool Status { get; set; }
	}
}
