using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.StatisticsDtos;

namespace RentACarAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticsController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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
            
            var responseMessage5= await client.GetAsync("https://localhost:44388/api/Statistics/GetLocationCount");

            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();

                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);

                ViewBag.locationCount = values5.LocationCount;
            }
            
            var responseMessage6= await client.GetAsync("https://localhost:44388/api/Statistics/GetBrandNameWithMostCars");

            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();

                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);

                ViewBag.brandName = values6.BrandName;
            }
            
            var responseMessage7= await client.GetAsync("https://localhost:44388/api/Statistics/GetBlogTitleWithMostComments");

            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();

                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);

                ViewBag.blogTitle = values7.BlogTitle;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:44388/api/Statistics/GetAutomaticCarCount");

            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();

                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);

                ViewBag.automaricCarCount = values8.AutomaricCarCount;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:44388/api/Statistics/GetCarCountUnder1000Km\r\n");

            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();

                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);

                ViewBag.carCountUnder1000Km = values9.CarCountUnder1000Km;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:44388/api/Statistics/GetAvgHourlyRentingPrice");

            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();

                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);

                ViewBag.avgHourlyPrice = values10.AvgHourlyPrice.ToString(".00", new CultureInfo("en-US"));

            }

            var responseMessage11 = await client.GetAsync("https://localhost:44388/api/Statistics/GetAvgDailyRentingPrice");

            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();

                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);

                ViewBag.avgDailyPrice = values11.AvgDailyPrice.ToString(".00", new CultureInfo("en-US"));
            }

            var responseMessage12 = await client.GetAsync("https://localhost:44388/api/Statistics/GetAvgMonthlyRentingPrice");

            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();

                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);

                ViewBag.avgMonthlyPrice = values12.AvgMonthlyPrice.ToString(".00", new CultureInfo("en-US"));
            }

            var responseMessage13 = await client.GetAsync("https://localhost:44388/api/Statistics/GetElectricCarCount");

            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();

                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);

                ViewBag.electricCarCount = values13.ElectricCarCount;
            }

            var responseMessage14 = await client.GetAsync("https://localhost:44388/api/Statistics/GetDieselOrGasolineCarCount");

            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();

                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);

                ViewBag.intCombCarCount = values14.IntCombCarCount;
            }

            var responseMessage15 = await client.GetAsync("https://localhost:44388/api/Statistics/GetMostAffordableCarName");

            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();

                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);

                ViewBag.mostAffordableCarName = values15.MostAffordableCarName;
            }

            var responseMessage16 = await client.GetAsync("https://localhost:44388/api/Statistics/GetMostExpensiveCarName");

            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();

                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);

                ViewBag.mostExpensiveCarName = values16.MostExpensiveCarName;
            }

            return View();
        }
    }
}
