using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarDtos;

namespace RentACarAPI.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainInfoComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainInfoComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(
                $"https://localhost:44388/api/Car/GetCarsWithIncludesById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCarWithIncludesDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
