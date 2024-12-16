

using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Sheep.SheepFullPrice.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.Sheep.SheepFullPrice
{
    public class FullPriceSheepRepository : Repository<SheepFullPriceEntity>, IFullPriceSheepRepository
    {
        private readonly SheepDbcontext _context;
        public FullPriceSheepRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<SheepFullPriceEntity> GetSheepBySheepId(Guid Id, CancellationToken cancellationToken)
        {
            return  await Table.SingleOrDefaultAsync(x => x.SheepId == Id, cancellationToken);
        }
    }
}
