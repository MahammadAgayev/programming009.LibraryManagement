using programming009.LibraryManagement.Settings;

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;

namespace programming009.LibraryManagement
{
    public static class ApplicationContext
    {
        public static AppSettings Settings { get; private set; }

        public static void Initialize()
        {
            Settings = InitializeSettings();
        }

        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsPath = Path.Combine(settingsPath, "LibraryManagement");

            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            return helper.GetSettings();
        }
    }
}
