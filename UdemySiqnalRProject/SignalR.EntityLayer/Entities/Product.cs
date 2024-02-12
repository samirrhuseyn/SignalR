using SignalR.EntityLayer.Entities;

namespace SiqnalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool ProductStatus { get; set;}
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
