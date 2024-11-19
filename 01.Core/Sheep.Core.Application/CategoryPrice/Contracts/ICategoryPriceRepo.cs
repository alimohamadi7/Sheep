
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.CategoryPrice.Contracts
{
    public interface ICategoryPriceRepo : IRepository<CategoryPriceEntity>
    {
        Task<OperationResult<GetQouery>> GetAll(CancellationToken cancellationToken);
    }
}
