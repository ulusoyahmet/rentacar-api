using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACarAPI.Dto.LocationDtos;

namespace RentACarAPI.WebUI.Controllers
{
    [Authorize(Roles = "Member,Admin,Visitor,Manager")]
    public class DefaultController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string alert)
        {
            var token = User.Claims
                .FirstOrDefault(x => x.Type == "accesstoken")?
                .Value;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.GetAsync("https://localhost:44388/api/Location");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> values = results.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.locations = values;

            ViewBag.alert = alert;


            return View();

        }

        [HttpPost]
        public IActionResult Index(string book_pick_date,
                                 string book_off_date,
                                 string time_pick,
                                 string time_off,
                                 string locationID)
        {
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;

            return RedirectToAction("Index", "CarRentingList", new { id = locationID });
        }
    }
}
