using System.ComponentModel.DataAnnotations.Schema;

namespace SiqnalR.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
        public string PersonCount { get; set; }
        public string Date { get; set; }
    }
}
