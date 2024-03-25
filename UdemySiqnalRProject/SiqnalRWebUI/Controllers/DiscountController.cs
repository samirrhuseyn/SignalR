using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DataAccessLayer.Concrete;
using SiqnalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.DiscountDto;
using SiqnalRWebUI.Dtos.DiscountDtos;
using System.Data;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    [Authorize(Roles = "Admin,Manager,Editor,")]
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        SignalRContext context = new SignalRContext();
        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscount createDiscount)
        {
            CreateDiscountDto createDiscountDto = new CreateDiscountDto()
            {
                Title = createDiscount.Title,
                Amount = createDiscount.Amount,
                Description = createDiscount.Description,
                ImageURL = UploadFile(createDiscount.ImageURL),
                Status = true
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/Discount", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/Discount/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var image = context.Discounts.Where(x => x.DiscountID == id).Select(x => x.ImageURL).FirstOrDefault();
            ViewBag.Image = image;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5056/api/Discount/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscount updateDiscount)
        {
            var image = context.Discounts.Where(x => x.DiscountID == updateDiscount.DiscountID).Select(x => x.ImageURL).FirstOrDefault();
            UpdateDiscountDto updateDiscountDto = new UpdateDiscountDto()
            {
                DiscountID = updateDiscount.DiscountID,
                Amount = updateDiscount.Amount,
                Description = updateDiscount.Description,
                ImageURL = updateDiscount.ImageURL != null ? UploadFile(updateDiscount.ImageURL) : image,
                Status = updateDiscount.Status,
                Title = updateDiscount.Title
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PutAsync("http://localhost:5056/api/Discount", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

		public IActionResult FalseStatus(int id)
		{
			var context = new SignalRContext();
			var value = context.Set<Discount>().Find(id);
			value.Status = false;
			context.Update(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ActiveStatus(int id)
		{
			var context = new SignalRContext();
			var value = context.Set<Discount>().Find(id);
			value.Status = true;
			context.Update(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Image/DiscountImages/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Image/DiscountImages/" + file.FileName;
        }
    }
}
