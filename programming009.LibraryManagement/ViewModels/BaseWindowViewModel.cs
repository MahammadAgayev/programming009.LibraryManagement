using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace programming009.LibraryManagement.ViewModels
{
    public class BaseWindowViewModel : INotifyPropertyChanged
    {
        public BaseWindowViewModel(Window window)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public Window Window { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyChange(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
