﻿using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
