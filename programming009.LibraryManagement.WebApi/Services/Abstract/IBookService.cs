using programming009.LibraryManagement.WebApi.Models;

namespace programming009.LibraryManagement.WebApi.Services.Abstract
{
    public interface IBookService
    {
        void Add(BookModel model);
        void Update(BookModel model);

        List<BookModel> Get();
        BookModel Get(int id);
    }
}
