using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagementWeb.Constants;
using programming009.LibraryManagementWeb.Models;

namespace programming009.LibraryManagementWeb.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            User user = _userManager.FindByNameAsync(model.Username).Result;

            if (user == null)
            {
                ModelState.AddModelError("ErrorMessage", "Username or password is incorrect");

                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            if (result.Succeeded == false)
            {
                ModelState.AddModelError("ErrorMessage", "Username or password is incorrect");

                return View(model);
            }

            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new RegisterModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model, string? returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            User user = new User
            {
                Username = model.Username,
                Email = model.Email,
            };

            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

            if(result.Succeeded == false)
            {
                string error = this.ExtractErrorMessage(result);
                ModelState.AddModelError("ErrorMessage", error);
                return View(model);
            }

            IdentityResult addToRoleResult = _userManager.AddToRoleAsync(user, Roles.Customer).Result;

            if(addToRoleResult.Succeeded == false)
            {
                ModelState.AddModelError("ErrorMessage", "Failed to create user");
                return View(model);
            }

            return Redirect(returnUrl ?? "/");
        }

        private string ExtractErrorMessage(IdentityResult result)
        {
            IEnumerable<IdentityError> errors = result.Errors;

            List<string> strErrors = new List<string>();
            foreach (var item in errors)
            {
                strErrors.Add(item.Description);
            }

            return string.Join("\n", strErrors);
        }
    }
}
