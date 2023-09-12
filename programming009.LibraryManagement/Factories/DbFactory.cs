using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.DataAccessLayer;
using programming009.LibraryManagement.Core.DataAccessLayer.SqlServer;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.Settings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Get(AppSettings appSettings)
        {
            switch (appSettings.DbType)
            {
                case Core.Domain.Enums.DatabaseType.SqlServer:
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.InitialCatalog = appSettings.DbName;
                    builder.DataSource = appSettings.DbHost;
                    builder.IntegratedSecurity = appSettings.WindowsAuthentication;
                    builder.TrustServerCertificate = true;

                    if (appSettings.WindowsAuthentication == false)
                    {
                        builder.UserID = appSettings.Username;
                        builder.Password = appSettings.Password;
                    }

                    string connectionString = builder.ToString();

                    return new SqlUnitOfWork(connectionString);
                case Core.Domain.Enums.DatabaseType.MySql:
                    return new EmptyUnitOfWork();
                case Core.Domain.Enums.DatabaseType.InMemory:
                    return new EmptyUnitOfWork();
                default:
                    throw new NotSupportedException($"{appSettings.DbType} not supported");
            }
        }
    }
}
