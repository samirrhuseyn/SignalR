using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SiqnalRWebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        [Required, DataType(DataType.Text), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Person Count")]
        public string PersonCount { get; set; }

        [Required, DataType(DataType.Time), Display(Name = "Date")]
        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
