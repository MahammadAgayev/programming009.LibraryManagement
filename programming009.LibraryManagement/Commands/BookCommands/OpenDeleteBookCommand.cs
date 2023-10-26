using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AuthorCommands
{
    public class OpenDeleteBookCommand : ICommand
    {
        private readonly BooksViewModel _viewModel;

        public OpenDeleteBookCommand(BooksViewModel viewModel)
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
            int index = _viewModel.SelectedBookIndex;

            BookModel model = _viewModel.BookModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.Name},{model.Genre}'?", "Delete Author", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            ApplicationContext.DB.AuthorBookRepository.DeleteByBook(model.Id);
            ApplicationContext.DB.BookRepository.Delete(model.Id);
            _viewModel.BookModels.Remove(model);
        }
    }
}
