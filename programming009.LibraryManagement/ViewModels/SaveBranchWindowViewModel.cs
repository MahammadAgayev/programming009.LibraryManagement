using programming009.LibraryManagement.Commands.BranchesCommands;
using programming009.LibraryManagement.Models;

using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class SaveBranchWindowViewModel : BaseWindowViewModel
    {
        public SaveBranchWindowViewModel(Window window) : base(window)
        {
            BranchModel = new BranchModel();
            SaveBranch = new SaveBranchCommand(this);
        }

        public BranchModel BranchModel { get; set; }
        public ICommand SaveBranch { get; set; }
    }
}
