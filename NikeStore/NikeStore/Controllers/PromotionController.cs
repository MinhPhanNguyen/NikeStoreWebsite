using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    public class PromotionController : Controller
    {
        private readonly DataContext _context;

        public PromotionController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var product = _context.Product.Include(p => p.ProductCategory).ToList();
            return View(product);
        }
    }
}
