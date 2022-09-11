using System.Linq;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Migrations;
using Netpower.Migrations.Entities;

namespace Netpower.Core.Data.Repositoties
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ProductStoreContext _context;
        public ProductRepository(ProductStoreContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProductById(int key)
        {
            return _context.Products.Where(x => x.Id == key);
        }
    }
}