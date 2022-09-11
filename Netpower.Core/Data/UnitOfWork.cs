using Netpower.Contracts.Data;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Core.Data.Repositoties;
using Netpower.Migrations;

namespace Netpower.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductStoreContext _context;

        public UnitOfWork(ProductStoreContext context)
        {
            _context = context;
        }

        public IProductRepository Products => new ProductRepository(_context);

        public IProductRatingRepository ProductRating => new ProductRatingRepository(_context);

        public ICategoryRepository Categorys => new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}