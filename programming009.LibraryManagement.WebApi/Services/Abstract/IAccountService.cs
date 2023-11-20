using programming009.LibraryManagement.WebApi.Models;

namespace programming009.LibraryManagement.WebApi.Services.Abstract
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(LoginModel model);
    }
}
