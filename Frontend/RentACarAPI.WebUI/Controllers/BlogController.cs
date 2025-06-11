using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BlogDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Our Blogs";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Blog/GetBlogWithFields");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithIncludesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blog Detail";
            ViewBag.blogId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Blog/GetBlogWithFields");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithIncludesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
