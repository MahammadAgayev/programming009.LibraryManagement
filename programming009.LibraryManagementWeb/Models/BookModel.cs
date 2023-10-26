using Microsoft.AspNetCore.Mvc.Rendering;

using programming009.LibraryManagement.Core.Domain.Enums;

using System.ComponentModel.DataAnnotations;

namespace programming009.LibraryManagementWeb.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Book price should be bigger than $1")]
        public decimal Price { get; set; }
    }
}
