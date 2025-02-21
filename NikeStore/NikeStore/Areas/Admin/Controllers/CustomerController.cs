using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NikeStore.Models;
using NikeStore.Repository;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Customer()
        {
            var customer = await _context.Customer.OrderBy(p => p.CustomerID).ToListAsync();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/customers");
                    string imageName = Guid.NewGuid().ToString() + "_" + customer.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await customer.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    customer.ImgUrl = imageName;
                }

                _context.Add(customer);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm tài khoản thành công";
                return RedirectToAction("Customer");
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

            return View(customer);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Customer customer = await _context.Customer.FindAsync(Id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var existingcustomer = await _context.Customer.FindAsync(Id);
                if (existingcustomer == null)
                {
                    return NotFound();
                }

                existingcustomer.CustomerName = customer.CustomerName;
                existingcustomer.Password = customer.Password;
                existingcustomer.Email = customer.Email;
                existingcustomer.PhoneNumber = customer.PhoneNumber;
                existingcustomer.Address = customer.Address;

                if (customer.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/customers");
                    string imageName = Guid.NewGuid().ToString() + "_" + customer.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await customer.ImageUpload.CopyToAsync(fs);
                    }
                    existingcustomer.ImgUrl = imageName;
                }

                _context.Update(existingcustomer);
                await _context.SaveChangesAsync();

                TempData["success"] = "Cập nhật tài khoản thành công";
                return RedirectToAction("Customer");
            }

            TempData["error"] = "Model bị lỗi, vui lòng thử lại.";
            return View(customer);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            Customer customer = await _context.Customer.FindAsync(Id);

            if (!string.Equals(customer.ImgUrl, "noimage.jpg"))
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/customers");
                string oldFileImgae = Path.Combine(uploadDir, customer.ImgUrl);

                if (System.IO.File.Exists(oldFileImgae))
                {
                    System.IO.File.Delete(oldFileImgae);
                }
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa tài khoản thành công";
            return RedirectToAction("Customer");
        }
    }
}
