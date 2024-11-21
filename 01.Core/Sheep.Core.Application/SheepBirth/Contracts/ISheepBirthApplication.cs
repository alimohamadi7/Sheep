using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.SheepBirth.Contracts
{
    public interface ISheepBirthApplication
    {
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task <GetSheepQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "");
    }
}
