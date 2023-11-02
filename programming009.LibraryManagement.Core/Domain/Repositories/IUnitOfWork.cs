﻿namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public IAuthorBookRepository AuthorBookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IBranchRepository BranchRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }

        bool IsOnline();
    }
}
