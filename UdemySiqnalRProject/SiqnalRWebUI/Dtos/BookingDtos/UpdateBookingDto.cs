﻿namespace SiqnalRWebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
