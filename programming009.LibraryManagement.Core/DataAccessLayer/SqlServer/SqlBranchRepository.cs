using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlBranchRepository : IBranchRepository
    {
        private readonly string _connectionString;

        public SqlBranchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Branch branch)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert into Branches values(@name, @address)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", branch.Name);
            cmd.Parameters.AddWithValue("address", branch.Address);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            const string query = "delete from branches where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public void Update(Branch branch)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update branches set name = @name, address = @address where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", branch.Id);
            cmd.Parameters.AddWithValue("name", branch.Name);
            cmd.Parameters.AddWithValue("address", branch.Address);

            cmd.ExecuteNonQuery();
        }

        public Branch Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from branches where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.Map(reader);
            }

            return null;
        }

        public List<Branch> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from branches";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Branch> result = new List<Branch>();

            while (reader.Read())
            {
                Branch branch = Mapper.Map(reader);
                result.Add(branch);
            }

            return result;
        }
    }
}
