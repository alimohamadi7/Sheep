using Sheep.Framework.Application.Operation;



namespace Sheep.Core.Application.Sheep.Contracts
{
    public interface ISheepApplication
    {
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> EditSell(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task <GetSheepQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "");
        Task CalculateAge(CancellationToken cancellationToken);
        Task <bool> IsExistSheepchild(Guid SheepId ,DateTime Start , DateTime End, CancellationToken cancellationToken);
        int GetSheepCount (CancellationToken cancellationToken);    
    }
}
