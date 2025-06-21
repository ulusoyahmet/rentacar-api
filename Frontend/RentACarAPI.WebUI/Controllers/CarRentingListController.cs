using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarRentingDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class CarRentingListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarRentingListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.locationID = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/CarRentings?locationID={id}&available=true");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarRentingFilterDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
