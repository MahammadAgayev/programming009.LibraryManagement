using programming009.LibraryManagement.Commands.BookCommands;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Enums;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels.Abstract;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class SaveBookViewModel : BaseWindowViewModel
    {
        public SaveBookViewModel(Window window, BooksViewModel parent) : base(window)
        {
            AddAuthorToList = new AddAuthorToListCommand(this);
            DeleteAuthorFromList = new DeleteAuthorFromListCommand(this);
            SaveBook = new SaveBookCommand(this);
            Parent = parent;
        }

        public BooksViewModel Parent { get; set; }

        public ICommand SaveBook { get; set; }
        public ICommand AddAuthorToList { get; set; }
        public ICommand DeleteAuthorFromList { get; set; }

        public BookModel BookModel { get; set; } = new BookModel();

        public ObservableCollection<AuthorModel> Authors { get; set; } = new ObservableCollection<AuthorModel>();
        public ObservableCollection<AuthorModel> SelectedAuthors { get; set; } = new ObservableCollection<AuthorModel>();
        public int SelectedAuthorToAdd { get; set; }
        public int SelectedAuthorToDelete { get; set; }
        public List<Genre> Genres { get; set; }

        public void Load(List<Author> authors)
        {
            foreach (Author author in authors)
            {
                AuthorModel model = new AuthorModel
                {
                    Id = author.Id,
                    Name = author.Name,
                    Surname = author.Surname,
                };

                Authors.Add(model);
            }

            Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
        }
    }
}
