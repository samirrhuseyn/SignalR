using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialID { get; set; }
        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Comment")]
        public string Comment { get; set; }

        [Required, DataType(DataType.ImageUrl), Display(Name = "ImamgeURL")]
        public string ImamgeURL { get; set; }
        public bool Status { get; set; }
    }
}
