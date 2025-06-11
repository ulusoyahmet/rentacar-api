using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.TagDtos;

namespace RentACarAPI.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudByBlogComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailTagCloudByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Tag/GetTagsByBlogId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetTagByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
