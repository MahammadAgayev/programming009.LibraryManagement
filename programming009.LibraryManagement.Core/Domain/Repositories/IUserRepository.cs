using programming009.LibraryManagement.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        User Get(string username);
    }
}
