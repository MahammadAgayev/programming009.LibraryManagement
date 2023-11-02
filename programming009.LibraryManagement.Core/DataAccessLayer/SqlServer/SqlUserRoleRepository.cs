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
    public class SqlUserRoleRepository : IUserRoleRepository
    {
        private readonly string _connectionString;

        public SqlUserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserRole> GetByRoleId(int roleId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRoles ur 
                                   join Users u on u.Id = ur.UserId
                                   join Roles r on r.Id = ur.RoleId
                                   where ur.roleId = @roleId";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("roleId", roleId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserRole> userRoles = new List<UserRole>();

            while (reader.Read())
            {
                UserRole userRole = Mapper.MapUserRole(reader);

                userRoles.Add(userRole);
            }

            return userRoles;
        }

        public List<UserRole> GetByUserId(int userId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRoles ur 
                                   join Users u on u.Id = ur.UserId
                                   join Roles r on r.Id = ur.RoleId
                                   where ur.userid = @userid";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("userId", userId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserRole> userRoles = new List<UserRole>();

            while (reader.Read())
            {
                UserRole userRole = Mapper.MapUserRole(reader);

                userRoles.Add(userRole);
            }

            return userRoles;
        }
    }
}
