using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationID { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string NotificationTypeColor { get; set; }
        public string NotificationTypeIcon { get; set; }
    }
}
