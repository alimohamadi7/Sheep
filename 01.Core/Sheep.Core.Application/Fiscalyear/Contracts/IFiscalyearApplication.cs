

using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Fiscalyear.Contracts
{
    public interface IFiscalyearApplication
    {
        Task<GetFiscalyearQuery> GetAll(CancellationToken cancellationToken);
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
    }
}
