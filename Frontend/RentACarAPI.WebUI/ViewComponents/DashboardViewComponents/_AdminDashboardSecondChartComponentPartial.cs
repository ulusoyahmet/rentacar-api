using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarPricingDto;

namespace RentACarAPI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardSecondChartComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardSecondChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/CarPricing/GetCarPricingsWithCarDetails");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var carListViewModel = JsonConvert.DeserializeObject<List<CarWithPricingDto>>(jsonData);

                return View();
            }

            return View();
        }
    }
}
