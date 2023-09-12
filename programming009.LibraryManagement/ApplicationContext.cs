using programming009.LibraryManagement.Core.Domain.Enums;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.Factories;
using programming009.LibraryManagement.Settings;

using System;
using System.IO;

namespace programming009.LibraryManagement
{
    public static class ApplicationContext
    {
        private static AppSettings _defaultSettings = new AppSettings
        {
            DbHost = "localhost",
            DbName = "default",
            DbPort = 1433,
            DbType = DatabaseType.SqlServer,
            Username = "",
            Password = "",
            WindowsAuthentication = true
        };

        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                settingsPath = Path.Combine(settingsPath, "LibraryManagement");

                if (Directory.Exists(settingsPath) == false){
                    Directory.CreateDirectory(settingsPath);
                }

                return settingsPath;
            }
        }


        public static AppSettings Settings { get; private set; }
        public static IUnitOfWork DB { get; private set; }

        public static void Initialize()
        {
            Settings = InitializeSettings();


            DB = DbFactory.Get(Settings);
        }

        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsPath = Path.Combine(settingsPath, "LibraryManagement");

            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            AppSettings appSettings = helper.GetSettings();

            if (appSettings is null)
            {
                appSettings = _defaultSettings;
            }

            return appSettings;
        }
    }
}
