using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;

using System.Data;

namespace programming009.LibraryManagement.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Branch MapBranch(IDataReader reader)
        {
            return new Branch
            {
                Name = (string)reader["Name"],
                Id = (int)reader["Id"],
                Address = (string)reader["Address"],
            };
        }

        public static Author MapAuthor(IDataReader reader)
        {
            return new Author
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"]
            };
        }
    }
}
