using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.DiscountDto
{
    public class UpdateDiscountDto
    {
        public int DiscountID { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Amount")]
        public string Amount { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Description")]
        public string Description { get; set; }

        [Required, DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageURL { get; set; }
        public bool Status { get; set; }
    }
}
