using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AuthorCommands
{
    public class OpenDeleteAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _viewModel;

        public OpenDeleteAuthorCommand(AuthorsViewModel viewModel)
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
            int index = _viewModel.SelectedAuthorIndex;

            AuthorModel model = _viewModel.AuthorModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.Name} {model.Surname}'?", "Delete Author", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            ApplicationContext.DB.AuthorRepository.Delete(model.Id);
            _viewModel.AuthorModels.Remove(model);
        }
    }
}
