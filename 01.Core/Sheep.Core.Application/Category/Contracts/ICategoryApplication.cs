using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Category.Contracts
{
    public interface ICategoryApplication
    {
        Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken);
        Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken);

    }
}
