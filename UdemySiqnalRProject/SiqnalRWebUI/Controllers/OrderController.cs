using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.MenuTableDtos;
using SiqnalRWebUI.Dtos.OrderDetailsDtos;
using SiqnalRWebUI.Dtos.OrderDtos;
using SiqnalRWebUI.Dtos.ProductDtos;
using System.Data;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    [Authorize(Roles = "Admin,Manager,Moderator,")]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Orders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/MenuTables");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsondata);
            List<SelectListItem> value = (from x in values.Where(x => x.Status is false)
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.MenuTableID.ToString()
                                          }).ToList();
            ViewBag.Values = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            createOrderDto.Description = "Custumer at the table";
            createOrderDto.TotalPrice = 0;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOrderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/Orders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult CloseInvoice(int id)
        {
            var context = new SignalRContext();
            var value = context.Set<Order>().Find(id);
            value.Description = "Invoice paid";
            context.Update(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/Orders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
    }
}
