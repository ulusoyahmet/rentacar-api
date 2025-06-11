using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BlogDtos;

namespace RentACarAPI.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAboutAuthorComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAboutAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Blog/GetBlogWithFields");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithIncludesDto>>(jsonData);
                return View(values.Where(x => x.BlogID == id));
            }
            return View();
        }
    }
}
