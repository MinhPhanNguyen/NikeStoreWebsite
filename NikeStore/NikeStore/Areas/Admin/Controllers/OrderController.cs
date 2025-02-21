using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }

        public IActionResult DoneOrder()
        {
            return View();
        }

        public IActionResult ProcessingOrder()
        {
            return View();
        }

        public IActionResult WaitingOrder()
        {
            return View();
        }
    }
}
