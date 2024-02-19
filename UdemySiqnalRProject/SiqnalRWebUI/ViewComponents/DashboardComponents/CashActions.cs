using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiqnalRWebUI.Dtos.MoneyCaseActionDtos;

namespace SiqnalRWebUI.ViewComponents.DashboardComponents
{
    public class CashActions : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;


        public CashActions(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/MoneyCaseActions/GetMoneyCaseActionList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMoneyCaseActionDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
