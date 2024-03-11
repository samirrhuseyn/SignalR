﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiqnalRWebUI.Dtos.SlideDtos;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _SliderNavigationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SliderNavigationComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5056/api/Sliders/GetSliderUI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSlideDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
