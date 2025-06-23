using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarBookingDtos;
using RentACarAPI.Dto.CarDtos;
using RentACarAPI.Dto.LocationDtos;
using RentACarAPI.Dto.TestimonialDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class CarBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarBookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Rent a Car";
            ViewBag.v2 = "Car Rental Form";
            ViewBag.id = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Location");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values = results.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.locations = values;

            var responseMessage2 = await client.GetAsync($"https://localhost:44388/api/Car/{id}");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            var results2 = JsonConvert.DeserializeObject<ResultCarDto>(jsonData2);

            ViewBag.carName = results2.Model;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateCarBookingDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/CarBookings", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default", new { alert = "Your car rental request has been received." });
            }

            return View();
        }
    }
}
