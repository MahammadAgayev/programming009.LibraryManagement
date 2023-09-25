using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AdminWindowCommands
{
    internal class OpenBooksCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenBooksCommand(AdminWindowViewModel viewModel)
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
            BooksControl control = new BooksControl();

            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.Load();

            control.DataContext = booksViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
