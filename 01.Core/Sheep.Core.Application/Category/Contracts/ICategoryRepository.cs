
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Category.Contracts
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        Task<OperationResult<GetCategoryQouery>> GetAll(CancellationToken cancellationToken);
    }
}
