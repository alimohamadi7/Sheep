

using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.Category.Repository
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {
        private readonly SheepDbcontext _context;
        public CategoryRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<OperationResult<GetCategoryQouery>> GetAll(CancellationToken cancellationToken)
        {
            List<CategoryEntity>? result = await TableNoTracking.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
            GetCategoryQouery getCategory = new GetCategoryQouery()
            {
                categoryEntities = result
            };

            OperationResult<GetCategoryQouery> operation = new OperationResult<GetCategoryQouery>()
            {
                Result = getCategory,
                isSuccedded = true,
            };
            return operation;
        }
    }
}
