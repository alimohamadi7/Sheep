
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Wages_overheads.Contracts
{
    public interface IWagesoverheadsApplication
    {
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task<GetWagesOverheadQuery> GetAll(CancellationToken cancellationToken, string? start, string?end,int pageId = 1);
    }
}
