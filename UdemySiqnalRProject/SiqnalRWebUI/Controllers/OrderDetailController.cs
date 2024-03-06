using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiqnalRWebUI.Dtos.OrderDetailsDtos;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5056/api/OrderDetails?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDetailDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
