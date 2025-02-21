using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private readonly DataContext _context;

        public WishListController(DataContext context)
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
