﻿using Microsoft.AspNetCore.Mvc;

namespace RunForLive.ViewComponents
{
    public class HeaderViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
