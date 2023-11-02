using programming009.LibraryManagement.Core.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Core.DataAccessLayer.SqlServer
{
    public class SqlRoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public SqlRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
