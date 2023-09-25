using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BranchesCommands
{
    public class OpenDeleteBranchCommand : ICommand
    {
        private readonly BranchesViewModel _viewModel;

        public OpenDeleteBranchCommand(BranchesViewModel viewModel)
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
            int index = _viewModel.SelectedBranchIndex;

            BranchModel model = _viewModel.BranchModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete {model.Name}?", "Delete branch", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            ApplicationContext.DB.BranchRepository.Delete(model.Id);
            _viewModel.BranchModels.Remove(model);
        }
    }
}
