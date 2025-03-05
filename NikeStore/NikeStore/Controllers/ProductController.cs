using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NikeStore.Models;
using NikeStore.Models.ViewModels;
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
            var products = await _dataContext.Product.Include(p => p.ProductCategory).Include(p => p.Images).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var product = await _dataContext.Product
                .Where(p => p.Name.Contains(searchTerm))
                .Include(p => p.Images)
                .ToListAsync();

            ViewBag.Keyword = searchTerm;

            return View(product);
        }

        public async Task<IActionResult> Details(long id)
        {
            if (id <= 0) return RedirectToAction("Index");
            var productById = _dataContext.Product
                .Where(p => p.ProductID == id)
                .Include(p => p.Images)
                .Include(p => p.ProductReview)
                .FirstOrDefault();

            var relatedProduct = await _dataContext.Product
                .Where(p => p.CategoryID == productById.CategoryID && p.ProductID != productById.ProductID)
                .Take(10)
                .ToListAsync();

            ViewBag.RelatedProduct = relatedProduct;

            var viewModel = new ProductDetailsViewModel
            {
                Product = productById,
            };

            return View(viewModel);
        }

        public IActionResult Comment(ProductReview productReview)
        {
            if (ModelState.IsValid)
            {
                var review = new ProductReview
                {
                    ProductId = productReview.ProductId,
                    Review = productReview.Review,
                    Rating = productReview.Rating,
                    Reviewer = User.Identity.Name,
                    ReviewerEmail = User.Identity.Name,
                };

                _dataContext.ProductReview.Add(review);
                _dataContext.SaveChanges();
                TempData["success"] = "Đánh giá sản phẩm thành công";

                return Redirect(Request.Headers["Referer"]);
            }
            else
            {
                TempData["error"] = "Model bị lỗi vui lòng thử lại";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                
                return RedirectToAction("Detai;s", new { id = productReview.ProductId });
            }

            return Redirect(Request.Headers["Referer"]);
        }
    }
}