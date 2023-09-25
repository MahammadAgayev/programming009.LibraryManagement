using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AuthorCommands
{
    public class OpenSaveAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _viewModel;

        private bool _isUpdate;

        public OpenSaveAuthorCommand(AuthorsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveAuthorCommand SetAsUpdate()
        {
            _isUpdate = true;

            return this;
        }

        public void Execute(object? parameter)
        {
            SaveAuthorWindow window = new SaveAuthorWindow();
            SaveAuthorWindowViewModel viewModel = new SaveAuthorWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedAuthorIndex;

                viewModel.AuthorModel = _viewModel.AuthorModels[selectedIndex];
            }

            window.Show();
        }
    }
}
