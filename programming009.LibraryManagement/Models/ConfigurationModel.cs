using programming009.LibraryManagement.Core.Domain.Enums;

namespace programming009.LibraryManagement.Models
{
    public class ConfigurationModel
    {
        public string DbHost { get; set; }
        public int DbPort { get; set; }
        public DatabaseType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
    }
}
