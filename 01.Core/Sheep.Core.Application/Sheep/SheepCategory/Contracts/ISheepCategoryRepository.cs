
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public interface ISheepCategoryRepository : IRepository<SheepCategoryEntity>
    {
        Task<List<GetSheepCategoryQuery>> GetAll(Guid SheepId, CancellationToken cancellationToken);
        int GetThreeSiXMaleCount();
        int GetThreeSixFemaleCount();
        int GetSixEighteenMaleCount();
        int GetSixEighteenFemaleCount();
        int GetZeroThreeMaleCount();
        int GetZeroEweFemaleCount();
        int GetEweCount();
        int GetRamCount();
        IQueryable<SheepCategoryEntity> GetsheepForCategory(CancellationToken cancellationToken, int PageId);
        Task<SheepCategoryEntity> GetSheepCategoryBySheepId(Guid Id, CancellationToken cancellationToken);
        IQueryable<SheepCategoryEntity> GetAllSixEighteen(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1);
        IQueryable<SheepCategoryEntity> GetAllThreeSix(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1);
        IQueryable<SheepCategoryEntity> GetAllEwe(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1);
        IQueryable<SheepCategoryEntity> GetAllRam(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1);

    }
}
