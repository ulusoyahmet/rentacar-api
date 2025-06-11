using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
