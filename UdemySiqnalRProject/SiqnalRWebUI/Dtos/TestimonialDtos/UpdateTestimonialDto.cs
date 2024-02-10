using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImamgeURL { get; set; }
        public bool Status { get; set; }
    }
}
