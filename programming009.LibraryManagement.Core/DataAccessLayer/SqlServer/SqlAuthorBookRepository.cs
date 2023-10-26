using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlAuthorBookRepository : IAuthorBookRepository
    {
        private readonly string _connectionString;

        public SqlAuthorBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AuthorBook authorBook)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into authorbooks(bookid, authorid) values(@bookid, @authorid)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("bookid", authorBook.BookId);
            cmd.Parameters.AddWithValue("authorid", authorBook.AuthorId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from authorbooks where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public void DeleteByBook(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from AuthorBooks where bookid =  @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public AuthorBook Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select ab.Id, ab.AuthorId, a.Name AuthorName, a.Surname AuthorSurname, ab.BookId, b.Name BookName, b.Price, b.Genre
from AuthorBooks ab
join Authors a on a.Id = ab.AuthorId
join Books b on b.Id = ab.BookId
where ab.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapAuthorBook(reader);
            }

            return null;
        }

        public List<AuthorBook> GetByAuthorId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select ab.Id, ab.AuthorId, a.Name AuthorName, a.Surname AuthorSurname, ab.BookId, b.Name BookName, b.Price, b.Genre
from AuthorBooks ab
join Authors a on a.Id = ab.AuthorId
join Books b on b.Id = ab.BookId
where a.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<AuthorBook> authorBooks = new List<AuthorBook>();

            while (reader.Read())
            {
                AuthorBook ab = Mapper.MapAuthorBook(reader);

                authorBooks.Add(ab);
            }

            return authorBooks;
        }

        public List<AuthorBook> GetByBookId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select ab.Id, ab.AuthorId, a.Name AuthorName, a.Surname AuthorSurname, ab.BookId, b.Name BookName, b.Price, b.Genre
from AuthorBooks ab
join Authors a on a.Id = ab.AuthorId
join Books b on b.Id = ab.BookId
where b.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<AuthorBook> authorBooks = new List<AuthorBook>();

            while (reader.Read())
            {
                AuthorBook ab = Mapper.MapAuthorBook(reader);

                authorBooks.Add(ab);
            }

            return authorBooks;
        }
    }
}
