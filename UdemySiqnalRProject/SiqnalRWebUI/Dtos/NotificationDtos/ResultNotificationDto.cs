﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.NotificationDtos
{
    public class ResultNotificationDto
    {
        public int NotificationID { get; set; }
        public int NotificationTypeID { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        
    }
}
