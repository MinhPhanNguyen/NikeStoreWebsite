﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PromotionController : Controller
    {
        public IActionResult Promotion()
        {
            return View();
        }

        public IActionResult PromotionCategory()
        {
            return View();
        }
    }
}
