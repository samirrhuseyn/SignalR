using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using SiqnalR.EntityLayer.Entities;
using SiqnalRWebUI.Dtos.TestimonialDtos;
using System.Data;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    [Authorize(Roles = "Admin,Manager,Editor")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        SignalRContext context = new SignalRContext();
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonial createTestimonial)
        {
            CreateTestimonialDto createTestimonialDto = new CreateTestimonialDto()
            {
                Name = createTestimonial.Name,
                Comment = createTestimonial.Comment,
                Title = createTestimonial.Title,
                ImamgeURL = UploadFile(createTestimonial.ImamgeURL),
                Status = true
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var image = context.Testimonials.Where(x=>x.TestimonialID == id).Select(x=>x.ImamgeURL).FirstOrDefault();
            ViewBag.Image = image;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5056/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonial>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonial updateTestimonial)
        {
            var image = context.Testimonials.Where(x => x.TestimonialID == updateTestimonial.TestimonialID).Select(x => x.ImamgeURL).FirstOrDefault();
            UpdateTestimonialDto updateTestimonialDto = new UpdateTestimonialDto()
            {
                Name = updateTestimonial.Name,
                Comment = updateTestimonial.Comment,
                Title = updateTestimonial.Title,
                TestimonialID = updateTestimonial.TestimonialID,
                Status = updateTestimonial.Status,
                ImamgeURL = updateTestimonial.ImageURL != null ? UploadFile(updateTestimonial.ImageURL) : image
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PutAsync("http://localhost:5056/api/Testimonial", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult FalseStatus(int id)
        {
            var context = new SignalRContext();
            var value = context.Set<Testimonial>().Find(id);
            value.Status = false;
            context.Update(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ActiveStatus(int id)
        {
            var context = new SignalRContext();
            var value = context.Set<Testimonial>().Find(id);
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
                        Directory.GetCurrentDirectory(), "wwwroot/Image/TestimonialImage/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Image/TestimonialImage/" + file.FileName;
        }
    }
}
