using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.BannerDtos;

namespace RentACarAPI.WebUI.ViewComponents.CarRentingViewComponents
{
    public class _CarRentingFilterComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarRentingFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string value)
        {
            TempData["value"] = value;
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44388/api/CarRenting");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            //    return View(values);
            //}
            return View();
        }
    }
}
