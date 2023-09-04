using programming009.LibraryManagement.Core.Domain.Enums;

namespace programming009.LibraryManagement.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }

        public List<Author> Authors { get; set; }
    }
}
