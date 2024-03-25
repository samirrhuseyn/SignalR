using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Menu Table")]
        public int MenuTableID { get; set; }

        
        public string Description { get; set; } 

        [Required, DataType(DataType.Time), Display(Name = "Date")]
        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
