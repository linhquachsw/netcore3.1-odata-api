using Netpower.Contracts.Data.Repositoties;

namespace Netpower.Contracts.Data
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IProductRatingRepository ProductRating { get; }
        ICategoryRepository Categorys { get; }
        void Commit();
    }
}