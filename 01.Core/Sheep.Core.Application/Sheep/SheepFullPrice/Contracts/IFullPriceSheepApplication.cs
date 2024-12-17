using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.SheepFullPrice.Contracts
{
    public interface IFullPriceSheepApplication
    {
        Task<SheepFullPriceEntity> GetSheepBySheepId(Guid Id ,CancellationToken cancellationToken);
        Task <OperationResult<bool>> Create(CreateCommand Command,CancellationToken cancellationToken);
    }
}
