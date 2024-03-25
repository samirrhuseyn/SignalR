using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.MenuTableDtos
{
    public class CreateMenuTableDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
