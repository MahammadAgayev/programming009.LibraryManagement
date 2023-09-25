using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AdminWindowCommands
{
    public class OpenAuthorsCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenAuthorsCommand(AdminWindowViewModel viewModel)
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
            AuthorsControl control = new AuthorsControl();

            AuthorsViewModel authosViewModel = new AuthorsViewModel();
            authosViewModel.Load();

            control.DataContext = authosViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
