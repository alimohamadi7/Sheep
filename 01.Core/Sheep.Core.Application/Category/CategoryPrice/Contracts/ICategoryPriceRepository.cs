
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public interface ICategoryPriceRepository : IRepository<CategoryPriceEntity>
    {
        Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, CategoryType categoryType, GenderType genderType, int PageId = 1);
        Task<IQueryable<CategoryPriceEntity>> GetCategoryByType(CategoryType categoryType,CancellationToken cancellationToken, int PageId = 1);
    }
}
