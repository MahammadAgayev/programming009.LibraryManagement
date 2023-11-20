using Microsoft.AspNetCore.Mvc;

using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Services.Abstract;

namespace programming009.LibraryManagement.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            LoginResponse response = await _accountService.Login(model);

            return Ok(response);
        }
    }
}
