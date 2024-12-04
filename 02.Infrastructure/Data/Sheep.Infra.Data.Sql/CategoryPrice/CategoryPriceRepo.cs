using Sheep.Core.Application.Category.CategoryPrice;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Infrastructure.Data;


namespace Sheep.Infra.Data.Sql.CategoryPrice
{
    public class CategoryPriceRepo : Repository<CategoryPriceEntity>, ICategoryPriceRepository
    {
        private readonly SheepDbcontext _context;
        public CategoryPriceRepo(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            throw new NotImplementedException();
        }
    }
}
