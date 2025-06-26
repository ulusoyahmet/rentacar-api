using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.StatisticsDtos;

namespace RentACarAPI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44388/api/Statistics/GetCarCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);

                ViewBag.carCount = values.CarCount;

            }

            var responseMessage2 = await client.GetAsync("https://localhost:44388/api/Statistics/GetAuthorCount");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);

                ViewBag.authorCount = values2.AuthorCount;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:44388/api/Statistics/GetBlogCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);

                ViewBag.blogCount = values3.BlogCount;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:44388/api/Statistics/GetBrandCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);

                ViewBag.brandCount = values4.BrandCount;
            }

            return View();
        }
    }
}
