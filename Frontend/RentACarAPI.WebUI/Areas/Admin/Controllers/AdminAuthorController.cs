using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.AuthorDtos;

namespace RentACarAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminAuthorController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Author");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);

                return View(results);
            }

            return View(new List<ResultAuthorDto>());
        }

        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Author", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/Author/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Author/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);

                return View(value);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/Author", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
