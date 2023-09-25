using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public SqlAuthorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Author author)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into authors output inserted.id values(@name, @surname)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", author.Name);
            cmd.Parameters.AddWithValue("surname", author.Surname);

            author.Id = (int)cmd.ExecuteScalar();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from authors where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public void Update(Author author)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update authors set name = @name, surname  = @surname";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", author.Name);
            cmd.Parameters.AddWithValue("surname", author.Surname);
            cmd.Parameters.AddWithValue("id", author.Id);

            cmd.ExecuteNonQuery();
        }

        public Author Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from authors where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapAuthor(reader);
            }

            return null;
        }


        public List<Author> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from authors";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Author> authors = new List<Author>();

            while (reader.Read())
            {
                Author author = Mapper.MapAuthor(reader);

                authors.Add(author);
            }

            return authors;
        }
    }
}
