using System.Collections.Generic;

namespace programming009.LibraryManagement.Misc.Abstract
{
    public interface IExporter<T>
    {
        void Export(IEnumerable<T> objects);
    }
}
