using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Infrastructure.Data;


namespace Sheep.Infra.Data.Sql.Sheep.PricePeriod.Repository
{
    public class SheepPricePeriodRepo:Repository<SheepFullPriceEntity>,ISheepPricePeriodRepo
    {
        private readonly SheepDbcontext _context;
        public SheepPricePeriodRepo(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
