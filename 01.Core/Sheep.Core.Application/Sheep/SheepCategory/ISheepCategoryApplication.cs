using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Sheep.SheepCategory
{
    public interface ISheepCategoryApplication
    {
        Task<EditSheepCategoryCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<SheepCategoryEntity> GetSheepCategoryById(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateSheepCategoryCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditSheepCategoryCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid SheepId, CancellationToken cancellationToken);
        Task<GetSheepCategoryQuery> GetAllSheepCategory(CancellationToken cancellationToken, int pageId = 1, string trim = "");
        Task CalculateSheepCategory (CancellationToken cancellationToken);
        Task<bool>CheckCaluteCategoryPeriod(Guid sheepId,CancellationToken cancellationToken);
        Task<IQueryable<SheepCategoryEntity>> GetAllZeroThree(SheepCategoryQuery Command , CancellationToken cancellationToken);
        IQueryable<SheepCategoryEntity> GetAllThreeSix(SheepCategoryQuery Command, CancellationToken cancellationToken,int PageId=1);
        Task SaveChangeAsync(CancellationToken cancellationToken);

    }
}
