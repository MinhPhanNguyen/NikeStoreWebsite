using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Controllers
{
    public class CaringController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
