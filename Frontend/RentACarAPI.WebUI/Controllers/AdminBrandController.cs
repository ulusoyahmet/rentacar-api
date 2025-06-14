using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BrandDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Brand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                return View(results);
            }

            return View(new List<ResultBrandDto>());
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Brand", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/Brand/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Brand/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);

                return View(value);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/Brand", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
