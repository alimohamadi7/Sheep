
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Cotrats.Data;

namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public interface ICategoryPriceRepository : IRepository<CategoryPriceEntity>
    {
        Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "");
    }
}
