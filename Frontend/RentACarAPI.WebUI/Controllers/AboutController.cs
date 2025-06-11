using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "About";
            ViewBag.v2 = "About Us";
            return View();
        }
    }
}
