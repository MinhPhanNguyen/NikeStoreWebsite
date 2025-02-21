using Microsoft.AspNetCore.Mvc;

namespace NikeStore.Controllers
{
    public class AuthShoeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
