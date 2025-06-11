using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BlogDtos;

namespace RentACarAPI.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Blog/GetBlogWithFields");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithIncludesDto>>(jsonData);
                return View(values?.Take(3).ToList());
            }
            return View();
        }
    }
}