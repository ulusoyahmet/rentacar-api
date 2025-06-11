using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
