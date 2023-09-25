using programming009.LibraryManagement.Core.Domain.Entities;
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
    public class SaveBookCommand : ICommand
    {
        private readonly SaveBookViewModel _viewModel;

        public SaveBookCommand(SaveBookViewModel viewModel)
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
            Book book = new Book
            {
                Name = _viewModel.BookModel.Name,
                Price = _viewModel.BookModel.Price,
                Genre = _viewModel.BookModel.Genre,
            };

            ApplicationContext.DB.BookRepository.Add(book);
            _viewModel.BookModel.Id = book.Id;

            foreach(AuthorModel model in _viewModel.SelectedAuthors)
            {
                AuthorBook ab = new AuthorBook
                {
                    AuthorId = model.Id,
                    BookId = book.Id
                };

                ApplicationContext.DB.AuthorBookRepository.Add(ab);
            }

            _viewModel.Parent.BookModels.Add(_viewModel.BookModel);
            _viewModel.Window.Close();
        }
    }
}
