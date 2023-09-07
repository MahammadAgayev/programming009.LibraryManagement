using programming009.LibraryManagement.Core.Domain.Entities;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IAuthorBookRepository
    {
        void Add(AuthorBook authorBook);
        void Delete(int id);

        AuthorBook Get(int id);
        List<AuthorBook> GetByBookId(int id);
        List<AuthorBook> GetByAuthorId(int id);
    }
}
