using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Migrations;
using Netpower.Migrations.Entities;

namespace Netpower.Core.Data.Repositoties
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}