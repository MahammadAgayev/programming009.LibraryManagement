using programming009.LibraryManagement.Commands.ConfigurationCommands;
using programming009.LibraryManagement.Core.Domain.Enums;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.Settings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window)
        {
            AppSettings currentSettings = ApplicationContext.Settings;

            Configuration = new ConfigurationModel
            {
                WindowsAuthentication = currentSettings.WindowsAuthentication,
                DbHost = currentSettings.DbHost,
                DbName = currentSettings.DbName,
                DbPort = currentSettings.DbPort,
                DbType = currentSettings.DbType,
                Username = currentSettings.Username,
            };

            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();

            Save = new SaveCommand(this);
            Cancel = new CancelCommand(this);
        }

        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType> SupportedDbTypes { get; set; }

        public ICommand Cancel { get; set; }

        public ICommand Save { get; set; }
    }
}
