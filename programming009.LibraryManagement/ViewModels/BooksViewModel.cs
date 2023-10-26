using programming009.LibraryManagement.Commands.AuthorCommands;
using programming009.LibraryManagement.Commands.BookCommands;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Misc;
using programming009.LibraryManagement.Misc.Abstract;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels.Abstract;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class BooksViewModel : IDataLoader
    {
        public BooksViewModel()
        {
            IExporter<BookModel> exporter = new CsvExporter<BookModel>();

            OpenAddBook = new OpenSaveBookCommand(this);
            OpenUpdateBook = new OpenSaveBookCommand(this).SetAsUpdate();
            OpenDeleteBook = new OpenDeleteBookCommand(this);
            ExportBooks = new ExportBooksCommand(this, exporter);
        }

        public ObservableCollection<BookModel> BookModels { get; set; }
        public ICommand OpenAddBook { get; set; }
        public ICommand OpenUpdateBook { get; set; }
        public ICommand OpenDeleteBook { get; set; }
        public ICommand ExportBooks { get; set; }
        public int SelectedBookIndex { get; set; }

        public void Load()
        {
            BookModels = new ObservableCollection<BookModel>();

            List<Book> books = ApplicationContext.DB.BookRepository.Get();

            foreach (Book book in books)
            {
                BookModel model = new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Genre = book.Genre,
                    Price = book.Price,
                };

                BookModels.Add(model);
            }
        }
    }
}
