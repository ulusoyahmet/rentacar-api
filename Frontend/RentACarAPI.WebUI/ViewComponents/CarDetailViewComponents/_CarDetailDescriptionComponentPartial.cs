using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarDescriptionDtos;

namespace RentACarAPI.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailDescriptionComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/CarDescriptions/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultCarDescriptionDto>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
