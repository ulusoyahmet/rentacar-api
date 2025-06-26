using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarRentingDtos;
using RentACarAPI.Dto.LocationDtos;

namespace RentACarAPI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardThirdChartComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardThirdChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44388/api/Location");

            var chartData = new List<LocationChartDto>();

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                foreach (var loc in locations.Take(6)) // limit to 6 locations
                {
                    var filterResponse = await client.GetAsync($"https://localhost:44388/api/CarRentings?locationID={loc.LocationID}&available=true");

                    int count = 0;
                    if (filterResponse.IsSuccessStatusCode)
                    {
                        var json = await filterResponse.Content.ReadAsStringAsync();
                        var filtered = JsonConvert.DeserializeObject<List<ResultCarRentingFilterDto>>(json);
                        count = filtered?.Count ?? 0;
                    }

                    chartData.Add(new LocationChartDto
                    {
                        Name = loc.Name,
                        Count = count
                    });
                }
            }

            return View(chartData);
        }

    }
}
