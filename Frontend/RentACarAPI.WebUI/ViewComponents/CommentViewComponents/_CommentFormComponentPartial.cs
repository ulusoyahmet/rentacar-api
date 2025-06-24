using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Dto.CommentDtos;

namespace RentACarAPI.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentFormComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke(int blogId)
        {
            ViewBag.blogId = blogId;
            return View(new CreateCommentDto { BlogID = blogId });
        }
    }
}
