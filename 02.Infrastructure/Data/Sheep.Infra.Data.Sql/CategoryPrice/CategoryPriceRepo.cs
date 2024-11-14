using Sheep.Core.Application.CategoryPrice;
using Sheep.Core.Application.CategoryPrice.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Infrastructure.Data;


namespace Sheep.Infra.Data.Sql.CategoryPrice
{
    public class CategoryPriceRepo : Repository<CategoryPriceEntity>, ICategoryPriceRepo
    {
        private readonly SheepDbcontext _context;
        public CategoryPriceRepo(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public Task<OperationResult<GetQouery>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
