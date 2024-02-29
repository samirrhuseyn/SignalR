using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Models
{
    public class ResultNotificationWithType
    {
        public int NotificationID { get; set; }
        public int NotificationTypeID { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string NotificationTypeTitle { get; set; }
        public string NotificationTypeColor { get; set; }
        public string NotificationTypeIcon { get; set; }
    }
}
