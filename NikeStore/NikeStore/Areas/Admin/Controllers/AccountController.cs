using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NikeStore.Models;
using NikeStore.Repository;
using System.Text.RegularExpressions;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Account()
        {
            var account = await _context.Account.OrderBy(p => p.AccountID).ToListAsync();
            return View(account);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Account account)
        {
            if (ModelState.IsValid)
            {
                if (account.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/accounts");
                    string imageName = Guid.NewGuid().ToString() + "_" + account.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await account.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    account.ImgUrl = imageName;
                }

                _context.Add(account);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm tài khoản thành công";
                return RedirectToAction("Account");
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

            return View(account);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Account account = await _context.Account.FindAsync(Id);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Account account)
        {
            if (ModelState.IsValid)
            {
                var existingAccount = await _context.Account.FindAsync(Id);
                if (existingAccount == null)
                {
                    return NotFound();
                }

                existingAccount.AccountName = account.AccountName;
                existingAccount.Password = account.Password;
                existingAccount.Email = account.Email;
                existingAccount.PhoneNumber = account.PhoneNumber;
                existingAccount.Address = account.Address;

                if (account.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/accounts");
                    string imageName = Guid.NewGuid().ToString() + "_" + account.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await account.ImageUpload.CopyToAsync(fs);
                    }
                    existingAccount.ImgUrl = imageName;
                }

                _context.Update(existingAccount);
                await _context.SaveChangesAsync();

                TempData["success"] = "Cập nhật tài khoản thành công";
                return RedirectToAction("Product");
            }

            TempData["error"] = "Model bị lỗi, vui lòng thử lại.";
            return View(account);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            Account account = await _context.Account.FindAsync(Id);

            if (!string.Equals(account.ImgUrl, "noimage.jpg"))
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/accounts");
                string oldFileImgae = Path.Combine(uploadDir, account.ImgUrl);

                if (System.IO.File.Exists(oldFileImgae))
                {
                    System.IO.File.Delete(oldFileImgae);
                }
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa tài khoản thành công";
            return RedirectToAction("Account");
        }
    }
}
