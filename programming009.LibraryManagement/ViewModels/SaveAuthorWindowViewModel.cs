using programming009.LibraryManagement.Commands.AuthorCommands;
using programming009.LibraryManagement.Models;

using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class SaveAuthorWindowViewModel : BaseWindowViewModel
    {
        public SaveAuthorWindowViewModel(Window window, AuthorsViewModel parent) : base(window)
        {
            this.AuthorModel = new AuthorModel();
            this.Parent = parent;
            this.SaveAuthor = new SaveAuthorCommand(this);
        }

        public AuthorModel AuthorModel { get; set; }
        public ICommand SaveAuthor { get; set; }
        public AuthorsViewModel Parent { get; set; }
    }
}