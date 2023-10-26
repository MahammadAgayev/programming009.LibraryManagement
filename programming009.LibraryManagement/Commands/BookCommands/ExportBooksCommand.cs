using programming009.LibraryManagement.Misc.Abstract;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels;

using System;
using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.Commands.BookCommands
{
    public class ExportBooksCommand : ICommand
    {
        private readonly IExporter<BookModel> _exporter;
        private readonly BooksViewModel _booksViewModel;

        public ExportBooksCommand(BooksViewModel booksViewModel, IExporter<BookModel> exporter)
        {
            _booksViewModel = booksViewModel;
            _exporter = exporter;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _exporter.Export(_booksViewModel.BookModels);

            MessageBox.Show("Books successfully exported", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
