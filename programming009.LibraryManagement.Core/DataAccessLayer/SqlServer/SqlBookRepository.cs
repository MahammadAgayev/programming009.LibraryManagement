using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Book book)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into books values(@name, @price, @genre)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", book.Name);
            cmd.Parameters.AddWithValue("price", book.Price);
            cmd.Parameters.AddWithValue("genre", book.Genre);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Book book)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from books where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", book.Id);

            cmd.ExecuteNonQuery();
        }

        public void Update(Book book)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update book set name = @name, price  = @price, genre = @genre";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public Book Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from books where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapBook(reader);
            }

            return null;
        }

        public List<Book> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from books";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Book> books = new List<Book>();

            while (reader.Read()) {
                Book b = Mapper.MapBook(reader);
                books.Add(b);
            }

            return books;
        }

    }
}
