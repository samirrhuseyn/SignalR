using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DataAccessLayer.Concrete;
using SiqnalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SiqnalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        SignalRContext context = new SignalRContext();
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5056/api/Contact/{2}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetContactDto>(jsonData);
				return View(values);
			}
			return View();
		}

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContact createContact)
        {
            CreateContactDto createContactDto = new CreateContactDto()
            {
                ProjectTitle = createContact.ProjectTitle,
                FooterDescription = createContact.Location,
                Location = createContact.Location,
                LocationIframe = createContact.LocationIframe,
                Phone = createContact.Phone,
                Mail = createContact.Mail,
                LogoImage = UploadFile(createContact.LogoImage)
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5056/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5056/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var image = context.Contacts.Where(x=>x.ContactID == id).Select(x=>x.LogoImage).FirstOrDefault();
            ViewBag.Image = image;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5056/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContact updatecontact)
        {
            var image = context.Contacts.Where(x => x.ContactID == updatecontact.ContactID).Select(x => x.LogoImage).FirstOrDefault();
            UpdateContactDto updateContactDto = new UpdateContactDto()
            {
                ContactID = updatecontact.ContactID,
                FooterDescription = updatecontact.FooterDescription,
                Location = updatecontact.Location,
                LocationIframe = updatecontact.LocationIframe,
                ProjectTitle = updatecontact.ProjectTitle,
                Mail = updatecontact.Mail,
                Phone = updatecontact.Phone,
                LogoImage = updatecontact.LogoImage != null ? UploadFile(updatecontact.LogoImage) : image
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PutAsync("http://localhost:5056/api/Contact", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Image/LogoImage/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Image/LogoImage/" + file.FileName;
        }
    }
}
