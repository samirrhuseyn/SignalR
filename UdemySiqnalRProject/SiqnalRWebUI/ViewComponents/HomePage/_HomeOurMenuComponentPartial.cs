﻿using Microsoft.AspNetCore.Mvc;

namespace SiqnalRWebUI.ViewComponents.HomePage
{
    public class _HomeOurMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}