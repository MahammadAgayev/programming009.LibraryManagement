using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IAuthorBookRepository AuthorBookRepository => new SqlAuthorBookRepository(_connectionString);

        public IAuthorRepository AuthorRepository => new SqlAuthorRepository(_connectionString);

        public IBookRepository BookRepository => new SqlBookRepository(_connectionString);

        public IBranchRepository BranchRepository => new SqlBranchRepository(_connectionString);

        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);

        public bool IsOnline()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
