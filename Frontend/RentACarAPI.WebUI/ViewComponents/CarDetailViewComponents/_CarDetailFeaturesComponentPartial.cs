using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarFeatureDtos;

namespace RentACarAPI.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailFeaturesComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailFeaturesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/CarFeatures/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

                int columnCount = 3; 

                int featuresPerColumn = values.Count / columnCount; 

                int extraFeatures = values.Count % columnCount;

                var columns = new List<List<ResultCarFeatureByCarIdDto>>();

                int startIndex = 0;

                for (int i = 0; i < columnCount; i++)
                {
                    int columnSize = featuresPerColumn + (extraFeatures > 0 ? 1 : 0);

                    if (extraFeatures > 0) extraFeatures--;

                    columns.Add(values.GetRange(startIndex, columnSize));

                    startIndex = columnSize;

                }

                return View(values);
            }

            return View();
        }
    }
}
