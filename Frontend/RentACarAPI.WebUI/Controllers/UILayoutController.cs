using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
