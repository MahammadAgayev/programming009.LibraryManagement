using programming009.LibraryManagement.Core.Domain.Entities;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IRoleRepository
    {
        Role GetByName(string name);
        Role GetById(int id);
    }
}