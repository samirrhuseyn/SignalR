namespace SiqnalRWebUI.Dtos.TestimonialDtos
{
    public class CreateTestimonial
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public IFormFile ImamgeURL { get; set; }
        public bool Status { get; set; }
    }
}
