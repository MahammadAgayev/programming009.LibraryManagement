using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.LoginCommands
{
    public class OpenRegisterCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;

        public OpenRegisterCommand(LoginWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.DataContext = new RegisterWindowViewModel(registerWindow);

            registerWindow.Show();
            _viewModel.Window.Close();
        }
    }
}
