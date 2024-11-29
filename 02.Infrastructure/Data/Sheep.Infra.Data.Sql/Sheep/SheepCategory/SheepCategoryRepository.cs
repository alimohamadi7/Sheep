using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Domain.Entities;
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

        public async Task<int> GetCount()
        {
          return  TableNoTracking.Count();
        }

        public IQueryable<SheepCategoryEntity> GetsheepForCategory(CancellationToken cancellationToken ,int rang1,int range2)
        {
            IQueryable<SheepCategoryEntity> result = TableNoTracking.Where(x => x.IsDeleted == false);
            return result.OrderByDescending(x=>x.CreatedDate).Take(rang1-range2);
        }
    }
}
