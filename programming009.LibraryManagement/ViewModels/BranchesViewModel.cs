using programming009.LibraryManagement.Commands.AdminWindowCommands;
using programming009.LibraryManagement.Commands.BranchesCommands;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels.Abstract;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class BranchesViewModel : IDataLoader
    {
        public BranchesViewModel()
        {
            this.OpenAddBranch = new OpenSaveBranchCommand(this);
            this.OpenUpdateBranch = new OpenSaveBranchCommand(this).SetForUpdate();
            this.OpenDeleteBranch = new OpenDeleteBranchCommand(this);
        }


        public ObservableCollection<BranchModel> BranchModels { get; set; }
        public ICommand OpenAddBranch { get; set; }
        public ICommand OpenUpdateBranch { get; set; }
        public ICommand OpenDeleteBranch { get; set; }
        public int SelectedBranchIndex { get; set; }

        public void Load()
        {
            this.BranchModels = new ObservableCollection<BranchModel>();
            List<Branch> branches = ApplicationContext.DB.BranchRepository.Get();

            foreach (Branch branch in branches)
            {
                BranchModel model = new BranchModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Address = branch.Address
                };

                this.BranchModels.Add(model);
            }
        }
    }
}
