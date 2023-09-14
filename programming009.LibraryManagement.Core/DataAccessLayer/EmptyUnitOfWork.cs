using programming009.LibraryManagement.Core.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Core.DataAccessLayer
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public IAuthorBookRepository AuthorBookRepository => throw new NotImplementedException();

        public IAuthorRepository AuthorRepository => throw new NotImplementedException();

        public IBookRepository BookRepository => throw new NotImplementedException();

        public IBranchRepository BranchRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public bool IsOnline()
        {
            return false;
        }
    }
}
