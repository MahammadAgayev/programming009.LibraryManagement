using programming009.LibraryManagement.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Update(Author author); 
        void Delete(int id);

        Author Get(int id);
        List<Author> Get();
    }
}
