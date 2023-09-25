using programming009.LibraryManagement.Commands.BranchesCommands;
using programming009.LibraryManagement.Models;

using System.Windows;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class SaveBranchWindowViewModel : BaseWindowViewModel
    {
        public SaveBranchWindowViewModel(Window window, BranchesViewModel parent) : base(window)
        {
            BranchModel = new BranchModel();
            SaveBranch = new SaveBranchCommand(this);
            Parent = parent;
        }

        public BranchModel BranchModel { get; set; }
        public ICommand SaveBranch { get; set; }
        public BranchesViewModel Parent { get; set; }
    }
}
