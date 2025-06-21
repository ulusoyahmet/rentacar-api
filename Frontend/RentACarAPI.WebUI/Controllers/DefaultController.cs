using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACarAPI.Dto.LocationDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class DefaultController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Location");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values = results.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.locations = values;

            return View();

        }

        // In DefaultController.cs
        [HttpPost]
        public IActionResult Index(string book_pick_date,
                                 string book_off_date,
                                 string time_pick,
                                 string time_off,
                                 string locationID)
        {
            // You can still use TempData for other values if needed
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;

            // Redirect with the locationID as a route parameter for the 'id' action parameter
            return RedirectToAction("Index", "CarRentingList", new { id = locationID });
        }

        //[HttpPost]
        //public IActionResult Index(string book_pick_date,
        //                   string book_off_date,
        //                   string time_pick,
        //                   string time_off,
        //                   string locationID)
        //{
        //    return RedirectToAction("Index", "CarRentingList", new
        //    {
        //        locationID = locationID,
        //        book_pick_date = book_pick_date,
        //        book_off_date = book_off_date,
        //        time_pick = time_pick,
        //        time_off = time_off
        //    });
        //}
    }
}
