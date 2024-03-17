using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DataAccessLayer.Concrete;
using SiqnalRWebUI.Dtos.NotificationDtos;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var context = new SignalRContext();
            var value = context.Notifications.Where(x => x.Status == false).ToList();
            foreach (var item in value)
            {
                item.Status = true;
            }
            context.SaveChanges();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Notifications/GetListAllNotification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult ReadAllNotification()
        {
            var context = new SignalRContext();
            var value = context.Notifications.Where(x=>x.Status == false).ToList(); 
            foreach(var item in value)
            {
                item.Status = true;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Statistic");
        }
    }
}
