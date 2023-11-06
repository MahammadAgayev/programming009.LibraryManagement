using Microsoft.AspNetCore.Identity;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagementWeb.Identity
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            Role role = _unitOfWork.RoleRepository.GetByName(roleName);

            if (role == null)
            {
                throw new InvalidOperationException($"Role with name {roleName}");
            }

            UserRole userRole = new UserRole
            {
                User = user,
                Role = role,
                UserId = user.Id,
                RoleId = role.Id
            };

            _unitOfWork.UserRoleRepository.Add(userRole);

            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            //TODO: will be implemented

            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (int.TryParse(userId, out int id) == false)
            {
                return Task.FromResult((User)null);
            }

            User user = _unitOfWork.UserRepository.GetById(id);

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.UserRepository.Get(normalizedUserName);

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username.ToUpperInvariant());
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            List<UserRole> userRoles = _unitOfWork.UserRoleRepository.GetByUserId(user.Id);

            List<string> roles = userRoles.Select(x => x.Role.Name).ToList();

            return Task.FromResult((IList<string>)roles);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            List<UserRole> userRoles = _unitOfWork.UserRoleRepository.GetByUserId(user.Id);

            List<string> roles = userRoles.Select(x => x.Role.Name.ToUpperInvariant()).ToList();

            return Task.FromResult(roles.Contains(roleName.ToUpperInvariant()));
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            //TODO: implement it

            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            //SKIPPED due to normalized username being not present
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            //TODO: implement update method
            //_unitOfWork.UserRepository.Update(user);

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
