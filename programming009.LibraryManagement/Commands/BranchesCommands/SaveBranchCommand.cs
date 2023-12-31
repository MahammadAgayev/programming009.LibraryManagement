﻿using programming009.LibraryManagement.Core.Domain.Entities;
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
                Id = model.Id,
                Name = model.Name,
                Address = model.Address
            };

            if (branch.Id > 0)
            {
                ApplicationContext.DB.BranchRepository.Update(branch);
            }
            else
            {
                ApplicationContext.DB.BranchRepository.Add(branch);

                model.Id = branch.Id;
                _viewModel.Parent.BranchModels.Add(model);
            }

            _viewModel.Window.Close();
        }
    }
}
