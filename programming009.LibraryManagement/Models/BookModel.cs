using programming009.LibraryManagement.Core.Domain.Enums;

using System;

namespace programming009.LibraryManagement.Models
{
    public class ReportFieldAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }

    public class BookModel
    {
        public int Id { get; set; }

        [ReportField(Order = 2, DisplayName = "Genre")]
        public Genre Genre { get; set; }

        [ReportField(Order = 1, DisplayName = "Name of book")]
        public string Name { get; set; }

        [ReportField(Order = 3, DisplayName = "Price of book")]
        public decimal Price { get; set; }
    }
}
