
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public interface ICategoryPriceRepository : IRepository<CategoryPriceEntity>
    {
        Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "");
        Task<IQueryable<CategoryPriceEntity>> GetCategoryByType(CategoryType categoryType,CancellationToken cancellationToken, int PageId = 1);
    }
}
