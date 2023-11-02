using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace programming009.LibraryManagementWeb.Controllers
{
    [AllowAnonymous]
    public class AccountController :  Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();  
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
