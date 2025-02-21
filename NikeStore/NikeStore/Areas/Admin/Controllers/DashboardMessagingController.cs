﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardMessagingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
