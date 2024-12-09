﻿using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.SheepCategory
{
    public interface ISheepCategoryApplication
    {
        Task<EditSheepCategoryCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Create(CreateSheepCategoryCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> IsExistSheep(CreateSheepCategoryCommand createCommand, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditSheepCategoryCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid SheepId, CancellationToken cancellationToken);
        Task<GetSheepCategoryQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "");
        Task CalculateSheepCategory (CancellationToken cancellationToken);

    }
}
