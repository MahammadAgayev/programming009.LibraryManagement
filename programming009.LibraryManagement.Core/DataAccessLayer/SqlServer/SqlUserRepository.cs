using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"insert into users output inserted.id values(@username, @passwordhash, @email)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("passwordhash", user.PasswordHash);
            cmd.Parameters.AddWithValue("email", user.Email);
             
            user.Id = (int)cmd.ExecuteScalar();
        }

        public User Get(string username)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from users where username = @username";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", username);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapUser(reader);
            }

            return null;
        }

        public User GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from users where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id ", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapUser(reader);
            }

            return null;
        }
    }
}