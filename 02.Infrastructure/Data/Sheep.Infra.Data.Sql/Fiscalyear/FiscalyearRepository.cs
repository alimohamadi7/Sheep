

using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Fiscalyear;
using Sheep.Core.Application.Fiscalyear.Contracts;
using Sheep.Core.Domain.Fiscalyear;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.Fiscalyear
{
    public class FiscalyearRepository : Repository<FiscalyearEntity>, IFiscalyearRepository
    {
        private readonly SheepDbcontext _context;
        public FiscalyearRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;

        }
        public async Task<GetFiscalyearQuery> GetAll(CancellationToken cancellationToken)
        {
            IQueryable<FiscalyearEntity>? result = TableNoTracking.Where(x => x.IsDeleted == false&&x.IsActive==true);
           return  new GetFiscalyearQuery() 
            {
                fiscalyearEntities=await result.ToListAsync(cancellationToken),
            };
        }

        public async Task<FiscalyearEntity> GetLastFiscalYear(CancellationToken cancellationToken)
        {
            return await Table.FirstOrDefaultAsync(x=>x.IsActive==true && x.IsDeleted==false);
        }
    }
}
