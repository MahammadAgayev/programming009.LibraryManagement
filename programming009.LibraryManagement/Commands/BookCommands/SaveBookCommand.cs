using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
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
                Id = _viewModel.BookModel.Id,
                Name = _viewModel.BookModel.Name,
                Price = _viewModel.BookModel.Price,
                Genre = _viewModel.BookModel.Genre,
            };


            if(book.Id > 0)
            {
                this.UpdateBook(book);
            }
            else
            {
                ApplicationContext.DB.BookRepository.Add(book);

                _viewModel.BookModel.Id = book.Id;
                _viewModel.Parent.BookModels.Add(_viewModel.BookModel);
            }

            foreach(AuthorModel model in _viewModel.SelectedAuthors)
            {
                AuthorBook ab = new AuthorBook
                {
                    AuthorId = model.Id,
                    BookId = book.Id
                };

                ApplicationContext.DB.AuthorBookRepository.Add(ab);
            }
            
            _viewModel.Window.Close();
        }

        private void UpdateBook(Book book)
        {
            ApplicationContext.DB.BookRepository.Update(book);
            ApplicationContext.DB.AuthorBookRepository.DeleteByBook(book.Id);
        }
    }
}
