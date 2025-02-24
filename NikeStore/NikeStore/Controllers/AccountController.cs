using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NikeStore.Models;
using NikeStore.Models.ViewModels;

namespace NikeStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private SignInManager<AppUserModel> _signInManager;

        public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn(string returnUrl)
        {
            return View(new LogInViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel login)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(login.AccountName, login.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(login);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Account user)
        {
            if (ModelState.IsValid)
            {
                AppUserModel newUser = new AppUserModel
                {
                    UserName = user.AccountName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("LogIn", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> LogOut(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
