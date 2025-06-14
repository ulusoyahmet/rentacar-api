using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.FeatureDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Feature");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(results);
            }

            return View(new List<ResultFeatureDto>());
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Feature", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/Feature/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Feature/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);

                return View(value);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/Feature", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
