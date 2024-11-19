using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Category.Contracts
{
    public interface ICategoryApplication
    {
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken);

    }
}
