using System.Data;

namespace programming009.LibraryManagement.Settings
{
    public class AppSettings
    {
        public string DbHost { get; set; }
        public string DbPort { get; set; }
        public DbType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
