using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BranchesCommands
{
    public class SaveBranchCommand : ICommand
    {
        private readonly SaveBranchWindowViewModel _viewModel;

        public SaveBranchCommand(SaveBranchWindowViewModel viewModel)
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
            BranchModel model = _viewModel.BranchModel;

            Branch branch = new Branch
            {
                Name = model.Name,
                Address = model.Address
            };

            ApplicationContext.DB.BranchRepository.Add(branch);

            _viewModel.Window.Close();
        }
    }
}
