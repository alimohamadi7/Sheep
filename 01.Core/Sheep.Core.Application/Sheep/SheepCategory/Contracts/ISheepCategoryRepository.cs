
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public interface ISheepCategoryRepository : IRepository<SheepCategoryEntity>
    {
        Task<List< GetSheepCategoryQuery>> GetAll(Guid SheepId,CancellationToken cancellationToken);
        Task<int> GetCount();
        IQueryable<SheepCategoryEntity> GetsheepForCategory(CancellationToken cancellationToken, int PageId);
        Task<SheepCategoryEntity> GetSheepCategoryBySheepId(Guid Id,CancellationToken cancellationToken);
        Task<IQueryable<SheepCategoryEntity>> GetAllZeroThree(SheepCategoryQuery Command, CancellationToken cancellationToken);
         IQueryable<SheepCategoryEntity> GetAllThreeSix(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1);

    }
}
