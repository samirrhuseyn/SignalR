namespace SiqnalRWebUI.Dtos.DiscountDtos
{
    public class CreateDiscount
    {
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public IFormFile ImageURL { get; set; }
        public bool Status { get; set; }
    }
}
