using SignalR.EntityLayer.Entities;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Models
{
    public class ResultOrderDetailWithProduct
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
