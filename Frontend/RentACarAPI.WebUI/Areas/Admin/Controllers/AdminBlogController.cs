using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACarAPI.Dto.AuthorDtos;
using RentACarAPI.Dto.BlogDtos;
using RentACarAPI.Dto.CategoryDtos;

namespace RentACarAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminBlogController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Blog/GetBlogWithFields");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<List<ResultBlogWithIncludesDto>>(jsonData);

                return View(results);
            }

            return View(new List<ResultBlogWithIncludesDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Category");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categories = values.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                }).ToList();

                ViewBag.categories = categories;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:44388/api/Author");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);

                List<SelectListItem> authors = values.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.AuthorID.ToString()
                }).ToList();

                ViewBag.authors = authors;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Blog", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/Blog/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage3 = await client.GetAsync("https://localhost:44388/api/Category");

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categories = values.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                }).ToList();

                ViewBag.categories = categories;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:44388/api/Author");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);

                List<SelectListItem> authors = values.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.AuthorID.ToString()
                }).ToList();

                ViewBag.authors = authors;
            }

            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Blog/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);

                return View(value);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44388/api/Blog", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
