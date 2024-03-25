using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SiqnalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.BookingDtos;
using System.Data;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        MailManager mailManager = new MailManager();
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize(Roles = "Admin,Editor,Manager")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Editor,Manager")]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Editor,Manager")]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index");
                
            }
            return View();
        }
        [Authorize(Roles = "Admin,Editor,Manager")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Editor,Manager")]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5056/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Editor,Manager")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PutAsync("http://localhost:5056/api/Booking", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin,Editor,Manager")]
        public IActionResult FalseStatus(int id)
        {
            var context = new SignalRContext();
            var value = context.Set<Booking>().Find(id);
            value.Status = false;
            context.Update(value);
            context.SaveChanges();
            mailManager.SendMail(value.Mail,
                "<!DOCTYPE html>" +
                "<html>" +
                "<body>" +
                "<h2>Reservation canceled!</h2>" +
                "<br/>" +
                "<h3>" + "Your reservation for date " + value.Date + " has been canceled." + "</h3>" +
                "</body>" +
                "</html>",
                "Reservation canceled");
            return RedirectToAction("Index");
        }
    }
}
