using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Enums;

using System.Net.NetworkInformation;

namespace programming009.LibraryManagement.WebApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Genre  Genre { get; set; }
    }

    public static class BookMapper
    {
        public static Book ToBook(BookModel model)
        {
            return new Book
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Genre = model.Genre
            };
        } 

        public static BookModel ToBookModel(Book b)
        {
            return new BookModel
            {
                Id = b.Id,
                Name = b.Name,
                Genre = b.Genre,
                Price = b.Price,
            };
        }
    }
}
