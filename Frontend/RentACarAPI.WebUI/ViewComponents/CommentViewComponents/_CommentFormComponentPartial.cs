using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentFormComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
