


using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.PricePeriod.Contracts
{
    public interface ISheepPricePeriodApp
    {
        Task<OperationResult<bool>> Create(CreateCommand command  , CancellationToken cancellationToken);
    }
}
