using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiqnalRWebUI.Dtos.MenuTableDtos;
using System.Data;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    [Authorize(Roles = "Admin,Manager,Moderator,")]
    public class MenuTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMenuTableDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/MenuTables", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
