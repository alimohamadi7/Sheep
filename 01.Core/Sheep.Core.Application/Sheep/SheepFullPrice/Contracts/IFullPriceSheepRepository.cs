

using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.SheepFullPrice.Contracts
{
    public interface IFullPriceSheepRepository:IRepository<SheepFullPriceEntity>
    {
        Task<SheepFullPriceEntity> GetSheepBySheepId(Guid Id, CancellationToken cancellationToken);

    }
}
