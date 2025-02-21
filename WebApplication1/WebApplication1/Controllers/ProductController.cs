using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Product()
        {
            var product = await _context.Product.OrderByDescending(p => p.ProductID)
                .Include(p => p.ProductCategory)
                .ToListAsync();
            return View(product);
        }

        public IActionResult HotProduct()
        {
            return View();
        }

        public IActionResult LoveProduct()
        {
            return View();
        }

        public IActionResult ReviewProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);

            if (ModelState.IsValid)
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Product");
            } else
            {
                TempData["error"] = "Model is in error";
                List<string> errors = new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

            return View(product);
        } 
    }
}
