using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BookCommands
{
    public class DeleteAuthorFromListCommand : ICommand
    {
        private readonly SaveBookViewModel _viewModel;

        public DeleteAuthorFromListCommand(SaveBookViewModel viewModel)
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
            AuthorModel authorToDelete = _viewModel.SelectedAuthors[_viewModel.SelectedAuthorToDelete];

            _viewModel.SelectedAuthors.Remove(authorToDelete);
            _viewModel.Authors.Add(authorToDelete);
        }
    }
}
