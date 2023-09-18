using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BranchesCommands
{
    public class OpenSaveBranchCommand : ICommand
    {
        private readonly BranchesViewModel _viewModel;

        public OpenSaveBranchCommand(BranchesViewModel viewModel)
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
            SaveBranchWindow window = new SaveBranchWindow();
            window.DataContext = new SaveBranchWindowViewModel(window);
            window.Show();
        }
    }
}
