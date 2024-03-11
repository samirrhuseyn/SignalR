namespace SiqnalRApi.Models
{
    public class ResultBasketListByTable
    {
        public int BasketID { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string MenuTableName { get; set; }
    }
}
