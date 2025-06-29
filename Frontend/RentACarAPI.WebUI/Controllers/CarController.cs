using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BlogDtos;
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

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Cars";
            ViewBag.v2 = "Car Detail";
            ViewBag.carId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Car/GetCarWithFields");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarWithPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}