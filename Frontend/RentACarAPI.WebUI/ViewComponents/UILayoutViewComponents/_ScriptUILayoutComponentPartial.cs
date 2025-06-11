using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
