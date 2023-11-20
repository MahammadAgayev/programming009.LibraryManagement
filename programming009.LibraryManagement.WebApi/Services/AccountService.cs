using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using NLog.Fluent;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Options;
using programming009.LibraryManagement.WebApi.Services.Abstract;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

namespace programming009.LibraryManagement.WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly SecurityOptions _options;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<SecurityOptions> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _options = options.Value;
        }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                throw new ApiException("Username or password is incorrect");
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded == false)
            {
                throw new ApiException("Username or password is incorrect");
            }

            string token = this.GenerateJwtToken(user);

            return new LoginResponse
            {
                Token = token
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                }),
                Expires = DateTime.Now.AddHours(1), //Token expires after 15 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "LibraryManagementAPI",
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
