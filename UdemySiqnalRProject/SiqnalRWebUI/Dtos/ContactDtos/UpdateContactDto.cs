using System.ComponentModel.DataAnnotations;

namespace SiqnalRWebUI.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Location")]
        public string Location { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Description")]
        public string FooterDescription { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Iframe")]
        public string LocationIframe { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string ProjectTitle { get; set; }

        [Required, DataType(DataType.ImageUrl), Display(Name = "Logo Image")]
        public string LogoImage { get; set; }
    }
}
