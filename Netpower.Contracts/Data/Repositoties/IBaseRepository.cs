using System.Collections.Generic;
using System.Linq;

namespace Netpower.Contracts.Data.Repositoties
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int Id);
    }
}