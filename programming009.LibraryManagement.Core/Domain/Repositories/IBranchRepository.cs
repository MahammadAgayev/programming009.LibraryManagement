using programming009.LibraryManagement.Core.Domain.Entities;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IBranchRepository
    {
        void Add(Branch branch);
        void Update(Branch branch); 
        void Delete(int id); 

        Branch Get(int id);
        List<Branch> Get();
    }
}
