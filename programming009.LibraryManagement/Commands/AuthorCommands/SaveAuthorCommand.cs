using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.AuthorCommands
{
    public class SaveAuthorCommand : ICommand
    {
        private readonly SaveAuthorWindowViewModel _viewModel;

        public SaveAuthorCommand(SaveAuthorWindowViewModel viewModel)
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
            AuthorModel model = _viewModel.AuthorModel;

            Author author = new Author
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname
            };

            if (author.Id > 0)
            {
                ApplicationContext.DB.AuthorRepository.Update(author);
            }
            else
            {
                ApplicationContext.DB.AuthorRepository.Add(author);
                model.Id = author.Id;

                _viewModel.Parent.AuthorModels.Add(model);
            }

            _viewModel.Window.Close();
        }
    }
}
