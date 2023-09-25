using Microsoft.Identity.Client;

using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BookCommands
{
    public class OpenSaveBookCommand : ICommand
    {
        private readonly BooksViewModel _booksViewModel;

        public OpenSaveBookCommand(BooksViewModel booksViewModel)
        {
            _booksViewModel = booksViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            SaveBookWindow window = new SaveBookWindow();
            SaveBookViewModel viewModel = new SaveBookViewModel(window, _booksViewModel);
            viewModel.Load();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
