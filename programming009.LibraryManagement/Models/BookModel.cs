﻿using programming009.LibraryManagement.Core.Domain.Enums;

namespace programming009.LibraryManagement.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
    }
}
