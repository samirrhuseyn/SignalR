namespace SiqnalRWebUI.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int MenuTableID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
