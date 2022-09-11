using System.Linq;
using Netpower.Migrations.Entities;

namespace Netpower.Contracts.Data.Repositoties
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IQueryable<Product> GetProductById(int key);
    }
}