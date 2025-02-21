using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    public class ProductListController : Controller
    {
        private readonly DataContext _context;

        public ProductListController( DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Product.Include(p => p.ProductCategory).ToListAsync();
            return View(products);
        }
    }
}
