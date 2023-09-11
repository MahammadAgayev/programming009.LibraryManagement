using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Settings
{
    public class AppSettingsHelper
    {
        private readonly string _configurationPath
            ;
        public AppSettingsHelper(string configurationPath)
        {
            _configurationPath = configurationPath;
        }

        public AppSettings GetSettings()
        {
            //"C:\downloads\test" "programming009.LibraryManagement.settings"
            // "C:\downloads\test\programming009.LibraryManagement.settings"

            string filename = Path.Combine(_configurationPath, "programming009.LibraryManagement.settings");

            if(File.Exists(filename) == false)
            {
                return null;
            }

            string settingsRaw = File.ReadAllText(filename);

            AppSettings settings = JsonConvert.DeserializeObject<AppSettings>(settingsRaw);

            return settings;
        }

        public void SaveSettings(AppSettings settings)
        {
            string settingsRaw = JsonConvert.SerializeObject(settings);

            string filename = Path.Combine(_configurationPath, "programming009.LibraryManagement.settings");

            File.WriteAllText(filename, settingsRaw);
        }
    }
}
