﻿using programming009.LibraryManagement.Core.Domain.Entities;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IBookRepository 
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);

        Book Get(int id);
        List<Book> Get();
    }
}
