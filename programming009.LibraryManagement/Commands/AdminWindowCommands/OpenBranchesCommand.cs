using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AdminWindowCommands
{
    public class OpenBranchesCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenBranchesCommand(AdminWindowViewModel viewModel)
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
            BranchesControl control = new BranchesControl();

            BranchesViewModel branchesViewModel = new BranchesViewModel();
            branchesViewModel.Load();

            control.DataContext = branchesViewModel;

            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}