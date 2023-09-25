using Newtonsoft.Json.Bson;

using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BranchesCommands
{
    public class OpenSaveBranchCommand : ICommand
    {
        private readonly BranchesViewModel _viewModel;

        private bool _isUpdate;

        public OpenSaveBranchCommand(BranchesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveBranchCommand SetForUpdate()
        {
            _isUpdate = true;

            return this;
        }

        public void Execute(object? parameter)
        {
            SaveBranchWindow window = new SaveBranchWindow();
            SaveBranchWindowViewModel viewModel = new SaveBranchWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedBranchIndex;

                viewModel.BranchModel = _viewModel.BranchModels[selectedIndex];
            }

            window.Show();
        }
    }
}
