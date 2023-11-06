using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlRoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public SqlRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Role GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from roles where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == false)
            {
                return null;
            }

            return Mapper.MapToRole(reader);
        }

        public Role GetByName(string name)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from roles where name = @name";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("name", name);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == false)
            {
                return null;
            }

            return Mapper.MapToRole(reader);
        }
    }
}
