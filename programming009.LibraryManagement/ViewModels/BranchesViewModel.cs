using programming009.LibraryManagement.Commands.AdminWindowCommands;
using programming009.LibraryManagement.Commands.BranchesCommands;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Models;
using programming009.LibraryManagement.ViewModels.Abstract;

using System.Collections.Generic;
using System.Windows.Input;

namespace programming009.LibraryManagement.ViewModels
{
    public class BranchesViewModel : IDataLoader
    {
        public BranchesViewModel() 
        {
            this.OpenSaveBranch = new OpenSaveBranchCommand(this);
        }


        public List<BranchModel> BranchModels { get; set; }
        public ICommand OpenSaveBranch { get; set; } 

        public void Load()
        {
            this.BranchModels = new List<BranchModel>();
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
