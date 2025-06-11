using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarPricingDto;

namespace RentACarAPI.WebUI.Controllers
{
    public class CarController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Cars";
            ViewBag.v2 = "Our Cars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/CarPricing/GetCarPricingsWithCarDetails");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var carListViewModel = JsonConvert.DeserializeObject<List<CarWithPricingDto>>(jsonData);

                return View(carListViewModel);
            }

            // If the API call fails, return a view with an empty list.
            return View(new List<CarWithPricingDto>());
        }
    }
}