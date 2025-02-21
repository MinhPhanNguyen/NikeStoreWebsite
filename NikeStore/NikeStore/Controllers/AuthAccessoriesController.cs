using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Controllers
{
    public class AuthAccessoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
