﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardSettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
