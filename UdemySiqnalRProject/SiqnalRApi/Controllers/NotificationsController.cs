using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;
using SiqnalRApi.Models;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("GetListAllNotification")]
        public IActionResult GetListAllNotification()
        {
            return Ok(_notificationService.GetAllNotifications());
        }
        

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.NotificationCountByStatusFalse());
        }

        //[HttpPost]
        //public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        //{
        //    Notification notification = new Notification()
        //    {
        //        NotificationDescription = createNotificationDto.NotificationDescription,
        //        Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
        //        NotificationTypeColor = createNotificationDto.NotificationTypeColor,
        //        NotificationTypeIcon = createNotificationDto.NotificationTypeIcon,
        //        Status = false
        //    };
        //    _notificationService.TAdd(notification);
        //    return Ok("Addition successful");
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Deletion successful");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        //[HttpPut]
        //public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        //{
        //    Notification notification = new Notification()
        //    {
        //        NotificationID = updateNotificationDto.NotificationID,
        //        NotificationDescription = updateNotificationDto.NotificationDescription,
        //        Date = updateNotificationDto.Date,
        //        NotificationTypeColor = updateNotificationDto.NotificationTypeColor,
        //        NotificationTypeIcon = updateNotificationDto.NotificationTypeIcon,
        //        Status = updateNotificationDto.Status
        //    };
        //    _notificationService.TUpdate(notification);
        //    return Ok("Update successful");
        //}

        //[HttpPost("AddNotificationByBooking")]
        //public IActionResult AddNotificationByBooking()
        //{
        //    Notification notification = new Notification()
        //    {
        //        NotificationDescription = "There is a new reservation!",
        //        Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
        //        NotificationTypeColor = "danger",
        //        NotificationTypeIcon = "las la-calendar-plus",
        //        Status = false
        //    };
        //    _notificationService.TAdd(notification);
        //    return Ok("Addition successful");
        //}
    }
}
