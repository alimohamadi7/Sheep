﻿using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Sheep.Contracts.Repository
{
    public interface ISheepRepository : IRepository<SheepEntity>
    {
        Task<GetSheepQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "");
        Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken);
    }
}
