﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult HistoryPayment()
        {
            return View();
        }
    }
}
