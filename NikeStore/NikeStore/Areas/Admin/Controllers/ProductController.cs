using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeStore.Models;
using NikeStore.Repository;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Product(int pg =1)
        {
            List<Product> product = await _context.Product.OrderBy(p => p.ProductID)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductGender)
                .Include(p => p.ProductSize)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductType)
                .ToListAsync();
           
            const int pageSize = 10;

            if(pg < 1)
            {
                pg = 1;
            }
            int recsCount = product.Count();

            var pager = new Paginate(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = product.Skip(recSkip).Take(pageSize).ToList();

            ViewBag.Pager = pager;

            return View(data);
        }

        public async Task<IActionResult> HotProduct(int pg = 1)
        {
            List<Product> product = await _context.Product.OrderBy(p => p.ProductID)
               .Include(p => p.ProductCategory)
               .Include(p => p.ProductGender)
               .Include(p => p.ProductSize)
               .Include(p => p.ProductColor)
               .Include(p => p.ProductType)
               .Where(p => p.IsHot == true)
               .ToListAsync();

            const int pageSize = 10;

            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = product.Count();

            var pager = new Paginate(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = product.Skip(recSkip).Take(pageSize).ToList();

            ViewBag.Pager = pager;

            return View(data);
        }

        public async Task<IActionResult> LoveProduct(int pg = 1)
        {
            List<Product> product = await _context.Product.OrderBy(p => p.ProductID)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductGender)
                .Include(p => p.ProductSize)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductType)
                .Where(p => p.IsFavorite == true)
                .ToListAsync();

            const int pageSize = 10;

            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = product.Count();

            var pager = new Paginate(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = product.Skip(recSkip).Take(pageSize).ToList();

            ViewBag.Pager = pager;

            return View(data);
        }

        //public async Task<IActionResult> ReviewProduct()
        //{
        //    var productReview = await _context.ProductReview.OrderBy(p => p.ReviewId)
        //        .Include(p => p.Product)
        //        .ToListAsync();
        //    return View(productReview);                                                                                                                                                                                 
        //}

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName");
            ViewBag.ProductType = new SelectList(_context.ProductType, "ProductTypeID", "Type");
            ViewBag.ProductColor = new SelectList(_context.ProductColor, "ProductColorID", "Color");
            ViewBag.ProductGender = new SelectList(_context.ProductGender, "GenderID", "GenderName");
            ViewBag.ProductSize = new SelectList(_context.ProductSize, "ProductSizeID", "Size");
            ViewBag.Warehouse = new SelectList(_context.Warehouse, "WarehouseID", "WarehouseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product)
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.ProductType = new SelectList(_context.ProductType, "ProductTypeID", "Type", product.ProductTypeID);
            ViewBag.ProductColor = new SelectList(_context.ProductColor, "ProductColorID", "Color", product.ProductColorID);
            ViewBag.ProductGender = new SelectList(_context.ProductGender, "GenderID", "GenderName", product.GenderID);
            ViewBag.ProductSize = new SelectList(_context.ProductSize, "ProductSizeID", "Size", product.ProductSizeID);
            ViewBag.Warehouse = new SelectList(_context.Warehouse, "WarehouseID", "WarehouseName", product.WarehouseID);

            if (ModelState.IsValid)
            {
                var category = await _context.ProductCategory.FindAsync(product.CategoryID);
                if (category != null)
                {
                    product.Slug = GenerateSlug(category.CategoryName);
                }
                else
                {
                    ModelState.AddModelError("", "Danh mục không tồn tại.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.ImageUrl = imageName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Product");
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
                return BadRequest(errorMessage);
            }

            return View(product);
        }

        public async Task<IActionResult> Edit(long Id)
        {
            Product product = await _context.Product.FindAsync(Id);
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.ProductType = new SelectList(_context.ProductType, "ProductTypeID", "Type", product.ProductTypeID);
            ViewBag.ProductColor = new SelectList(_context.ProductColor, "ProductColorID", "Color", product.ProductColorID);
            ViewBag.ProductGender = new SelectList(_context.ProductGender, "GenderID", "GenderName", product.GenderID);
            ViewBag.ProductSize = new SelectList(_context.ProductSize, "ProductSizeID", "Size", product.ProductSizeID);
            ViewBag.Warehouse = new SelectList(_context.Warehouse, "WarehouseID", "WarehouseName", product.WarehouseID);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long Id, Product product)
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.ProductType = new SelectList(_context.ProductType, "ProductTypeID", "Type", product.ProductTypeID);
            ViewBag.ProductColor = new SelectList(_context.ProductColor, "ProductColorID", "Color", product.ProductColorID);
            ViewBag.ProductGender = new SelectList(_context.ProductGender, "GenderID", "GenderName", product.GenderID);
            ViewBag.ProductSize = new SelectList(_context.ProductSize, "ProductSizeID", "Size", product.ProductSizeID);
            ViewBag.Warehouse = new SelectList(_context.Warehouse, "WarehouseID", "WarehouseName", product.WarehouseID);

            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Product.FindAsync(Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.ProductTypeID = product.ProductTypeID;
                existingProduct.ProductColorID = product.ProductColorID;
                existingProduct.GenderID = product.GenderID;
                existingProduct.ProductSizeID = product.ProductSizeID;

                var category = await _context.ProductCategory.FindAsync(product.CategoryID);
                if (category != null)
                {
                    existingProduct.Slug = GenerateSlug(category.CategoryName);
                }
                else
                {
                    ModelState.AddModelError("", "Danh mục không tồn tại.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await product.ImageUpload.CopyToAsync(fs);
                    }
                    existingProduct.ImageUrl = imageName;
                }

                _context.Update(existingProduct);
                await _context.SaveChangesAsync();

                TempData["success"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Product");
            }

            TempData["error"] = "Model bị lỗi, vui lòng thử lại.";
            return View(product);
        }

        private string GenerateSlug(string name)
        {
            if (string.IsNullOrEmpty(name)) return "";

            string slug = name.ToLower().Trim();

            // Thay thế nhiều khoảng trắng liên tiếp bằng chuỗi rỗng (xóa khoảng trắng)
            slug = Regex.Replace(slug, @"\s+", "");

            // Loại bỏ các ký tự đặc biệt (giữ lại chữ cái và số)
            slug = Regex.Replace(slug, @"[^a-z0-9]", "");

            return slug;
        }

        public async Task<IActionResult> Delete(long Id)
        {
            Product product = await _context.Product.FindAsync(Id);

            if(!string.Equals(product.ImageUrl,"noimage.jpg"))
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                string oldFileImgae = Path.Combine(uploadDir, product.ImageUrl);

                if(System.IO.File.Exists(oldFileImgae))
                {
                    System.IO.File.Delete(oldFileImgae);
                }    
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa sản phẩm thành công";
            return RedirectToAction("Product");
        } 
    }
}
