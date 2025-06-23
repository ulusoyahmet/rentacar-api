using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarPricingDto;

namespace RentACarAPI.WebUI.Controllers
{
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Rental Prices";
            ViewBag.v2 = "Packages";

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
