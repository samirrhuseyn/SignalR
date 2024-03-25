using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.SlideDtos
{
    public class CreateSlideDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Description")]
        [MaxLength(120, ErrorMessage = "This field cannot exceed 120 characters!")]
        [MinLength(3, ErrorMessage = "This field cannot be less than 120 characters!")]
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
