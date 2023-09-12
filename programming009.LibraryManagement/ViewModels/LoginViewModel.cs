using programming009.LibraryManagement.Models;

using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginViewModel(Window window) : base(window)
        {
        }

        public LoginModel LoginModel { get; set; }
        public ICommand Login { get; set; }
    }
}
