
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.CategoryPrice.Contracts
{
    public interface ICategoryPriceApp
    {
        Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken);
        Task<OperationResult<GetQouery>> GetAllCategory(CancellationToken cancellationToken);
    }
}
