using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    [Authorize]
    public class ProductDetailController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductDetailController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return RedirectToAction("Index");
            var productById = _dataContext.Product.Where(p => p.ProductID == id).FirstOrDefault();
            return View(productById);
        }
    }
}