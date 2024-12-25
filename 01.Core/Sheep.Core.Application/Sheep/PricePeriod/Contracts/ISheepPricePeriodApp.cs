


using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.PricePeriod.Contracts
{
    public interface ISheepPricePeriodApp
    {
        Task<OperationResult<bool>> ThreeSixCreate(CreateCommand command  , CancellationToken cancellationToken);
        Task<OperationResult<bool>> SixEighteenCreate(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> EweCreate(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> RamCreate(CreateCommand command, CancellationToken cancellationToken);
    }
}
