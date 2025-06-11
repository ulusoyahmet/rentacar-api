using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
