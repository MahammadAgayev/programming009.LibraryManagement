using programming009.LibraryManagement.Commands.AuthorCommands;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels.Abstract;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class AuthorsViewModel : IDataLoader
    {
        public AuthorsViewModel()
        {
            this.OpenAddAuthor = new OpenSaveAuthorCommand(this);
            this.OpenUpdateAuthor = new OpenSaveAuthorCommand(this).SetAsUpdate();
            this.OpenDeleteAuthor = new OpenDeleteAuthorCommand(this);
        }

        public ObservableCollection<AuthorModel> AuthorModels { get; set; }
        public ICommand OpenAddAuthor { get; set; }
        public ICommand OpenUpdateAuthor { get; set; }
        public ICommand OpenDeleteAuthor { get; set; }

        public int SelectedAuthorIndex { get; set; }

        public void Load()
        {
            List<Author> authors = ApplicationContext.DB.AuthorRepository.Get();

            AuthorModels = new ObservableCollection<AuthorModel>();

            foreach (Author a in authors)
            {
                AuthorModel model = new AuthorModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Surname = a.Surname
                };

                AuthorModels.Add(model);
            }
        }
    }
}
