using programming009.LibraryManagement.Commands.AdminWindowCommands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(AdminWindow window) : base(window)
        {
            OpenBranches = new OpenBranchesCommand(this);
            OpenAuthors = new OpenAuthorsCommand(this);
            OpenBooks = new OpenBooksCommand(this);
        }

        public ICommand OpenBranches { get; set; }
        public ICommand OpenAuthors { get; set; }
        public ICommand OpenBooks { get; set; }
        public Grid CenterGrid { get; set; }
    }
}
