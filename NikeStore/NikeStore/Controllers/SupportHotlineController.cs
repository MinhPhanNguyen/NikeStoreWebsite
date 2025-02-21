using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Controllers
{
    public class SupportHotlineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
