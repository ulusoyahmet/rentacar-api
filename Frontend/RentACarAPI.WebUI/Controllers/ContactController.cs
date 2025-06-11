using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarAPI.Dto.CarDtos;
using RentACarAPI.Dto.ContactDtos;

namespace RentACarAPI.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Contact";
            ViewBag.v2 = "Contact Us";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            dto.SentDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44388/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact");
            }

            return View();
        }
    }
}
