using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.StatisticsDtos;

namespace RentACarAPI.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44388/api/Statistics/GetCarCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);

                ViewBag.carCount = values.CarCount;

            }

            var responseMessage4 = await client.GetAsync("https://localhost:44388/api/Statistics/GetBrandCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);

                ViewBag.brandCount = values4.BrandCount;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:44388/api/Statistics/GetLocationCount");

            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();

                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);

                ViewBag.locationCount = values5.LocationCount;
            }


            return View();
        }
    }
}
