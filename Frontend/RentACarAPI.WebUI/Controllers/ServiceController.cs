using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Services";
            ViewBag.v2 = "Our Services";
            return View();
        }
    }
}
