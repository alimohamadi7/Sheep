using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;


namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public interface ISheepCategoryRepository : IRepository<SheepCategoryEntity>
    {
        Task<List< GetSheepCategoryQuery>> GetAll(Guid SheepId,CancellationToken cancellationToken);
    }
}
