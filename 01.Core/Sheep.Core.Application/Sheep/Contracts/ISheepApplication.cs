using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Contracts
{
    public interface ISheepApplication
    {
        Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken);
        Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken);
        Task<OperationResult<GetSheepQuery>> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "");
    }
}
