using Microsoft.AspNetCore.Identity;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagementWeb.Identity
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            Role role = _unitOfWork.RoleRepository.GetById(int.Parse(roleId));

            return Task.FromResult(role);
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            Role role = _unitOfWork.RoleRepository.GetByName(normalizedRoleName);

            return Task.FromResult(role);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name.ToUpperInvariant());
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            //SKIPPED;

            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;

            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            //TODO: no need to update

            return Task.FromResult(IdentityResult.Success);
        }
    }
}