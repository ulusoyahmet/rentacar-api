using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarFeatureDtos;
using RentACarAPI.Dto.CategoryDtos;

namespace RentACarAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/CarFeatures/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<UpdateCarFeatureByCarIdDto> dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/CarFeatures", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = dto.FirstOrDefault()?.CarID });
            }

            return View(dto);
        }
    }
}
