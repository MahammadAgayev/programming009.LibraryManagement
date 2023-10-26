using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagementWeb.Models;

namespace programming009.LibraryManagementWeb.Mappers
{
    public static class BookMapper
    {
        public static BookModel Map(Book b)
        {
            return new BookModel
            {
                Id = b.Id,
                Name = b.Name,
                Genre = b.Genre,
                Price = b.Price,
            };
        }

        public static Book Map(BookModel m)
        {
            return new Book
            {
                Id = m.Id,
                Name = m.Name,
                Genre = m.Genre,
                Price = m.Price
            };
        }
    }
}
