using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;
using programming009.LibraryManagement.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BookCommands
{
    public class OpenSaveBookCommand : ICommand
    {
        private readonly BooksViewModel _booksViewModel;
        private bool _isUpdate;

        public OpenSaveBookCommand(BooksViewModel booksViewModel)
        {
            _booksViewModel = booksViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveBookCommand SetAsUpdate()
        {
            _isUpdate = true;

            return this;
        }

        public void Execute(object? parameter)
        {
            SaveBookWindow window = new SaveBookWindow();
            SaveBookViewModel viewModel = new SaveBookViewModel(window, _booksViewModel);
            List<Author> allAuthors = ApplicationContext.DB.AuthorRepository.Get();

            if (_isUpdate)
            {
                int selectedIndex = _booksViewModel.SelectedBookIndex;

                viewModel.BookModel = _booksViewModel.BookModels[selectedIndex];

                List<AuthorBook> authors = ApplicationContext.DB.AuthorBookRepository.GetByBookId(viewModel.BookModel.Id);

                foreach(AuthorBook authorBook in authors)
                {
                    viewModel.SelectedAuthors.Add(new Models.AuthorModel
                    {
                        Id = authorBook.Id,
                        Name = authorBook.Author.Name, 
                        Surname = authorBook.Author.Surname 
                    });

                    allAuthors.RemoveAll(x => x.Id == authorBook.Author.Id);
                }
            }

            viewModel.Load(allAuthors);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
