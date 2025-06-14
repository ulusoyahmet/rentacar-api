using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BannerDtos;

namespace RentACarAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminBannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Banner");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);

                return View(results);
            }

            return View(new List<ResultBannerDto>());
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Banner", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                //return RedirectToAction("Index", "AdminBanner", new {area = "Admin"});
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/Banner/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Banner/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);

                return View(value);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/Banner", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
