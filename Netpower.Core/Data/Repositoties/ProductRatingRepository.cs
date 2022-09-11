using System.Linq;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Migrations;
using Netpower.Migrations.Entities;

namespace Netpower.Core.Data.Repositoties
{
    public class ProductRatingRepository : BaseRepository<ProductRating>, IProductRatingRepository
    {
        private ProductStoreContext _context;
        public ProductRatingRepository(ProductStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}