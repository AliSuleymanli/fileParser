using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> getAll();
        Task<T> getById(int id);
        Task<T> Insert(T newItem);

    }
}
