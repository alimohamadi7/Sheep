using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.Sheep.SheepCategory
{
    public class SheepCategoryRepository : Repository<SheepCategoryEntity>, ISheepCategoryRepository
    {
        private readonly SheepDbcontext _context;
        public SheepCategoryRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<GetSheepCategoryQuery>> GetAll(Guid SheepId, CancellationToken cancellationToken)
        {
            return  await TableNoTracking.Where(x =>x.SheepId==SheepId)
                      .Select(x => new GetSheepCategoryQuery { id = x.Id }).ToListAsync(cancellationToken);

        }
    }
}
