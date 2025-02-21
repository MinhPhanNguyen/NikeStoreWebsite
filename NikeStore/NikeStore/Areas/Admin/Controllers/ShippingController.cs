using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ShippingController : Controller
    {
        public IActionResult Shipping()
        {
            return View();
        }
    }
}
