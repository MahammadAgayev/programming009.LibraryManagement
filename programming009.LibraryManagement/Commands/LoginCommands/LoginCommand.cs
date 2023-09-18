using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Utils;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.LoginCommands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;

        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel ?? throw new ArgumentNullException(nameof(loginWindowViewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string username = _loginWindowViewModel.LoginModel.Username;
            
            User user = ApplicationContext.DB.UserRepository.Get(username);

            if(user == null)
            {
                this.Fail(username);
                return;
            }

            string password = ((PasswordBox)parameter).Password;
            string passwordHash = HashHelper.Hash(password);

            if(user.PasswordHash != passwordHash)
            {
                this.Fail(username);
                return;
            }

            ApplicationContext.CurrentUser = user;

            AdminWindow window = new AdminWindow();

            AdminWindowViewModel viewModel = new AdminWindowViewModel(window);
            viewModel.CenterGrid = window.grdCenter;
            
            window.DataContext = viewModel;
            window.Show();
            _loginWindowViewModel.Window.Close();
        }
      

        private void Fail(string username)
        {
            _loginWindowViewModel.LoginModel = new Models.LoginModel
            {
                Password = "",
                Username = username,
            };

            _loginWindowViewModel.ErrorVisibility = Visibility.Visible;
        }
    }
}
