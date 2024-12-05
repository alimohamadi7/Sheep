using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Category.Contracts
{
    public interface ICategoryApplication
    {
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken);
        Task<CategoryEntity> GetCategoryByCategoryType(CategoryType categoryType,CancellationToken cancellationToken);
        Task<List<CategoryEntity>> GetAllCategoryForFood(CancellationToken cancellationToken);
    }
}
