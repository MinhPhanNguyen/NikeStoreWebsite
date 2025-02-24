using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dataContext.Product.Include(p => p.ProductCategory).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return RedirectToAction("Index");
            var productById = _dataContext.Product.Where(p => p.ProductID == id).FirstOrDefault();
            return View(productById);
        }
    }
}