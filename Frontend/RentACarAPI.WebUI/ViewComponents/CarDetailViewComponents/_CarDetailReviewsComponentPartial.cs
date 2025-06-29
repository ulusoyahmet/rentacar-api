using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.ReviewDtos;

namespace RentACarAPI.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailReviewsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailReviewsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Reviews/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultReviewDto>>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
