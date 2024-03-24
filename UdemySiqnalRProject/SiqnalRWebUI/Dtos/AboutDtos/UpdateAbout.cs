namespace SiqnalRWebUI.Dtos.AboutDtos
{
    public class UpdateAbout
    {
        public int AboutID { get; set; }
        public IFormFile ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
