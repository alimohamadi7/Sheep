

using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;
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

        public async Task<List<CategoryEntity>> GetAllCategoryForFood(CancellationToken cancellationToken)
        {
            return await Entities.ToListAsync(cancellationToken);
        }

        public async Task<CategoryEntity> GetCategoryByCategoryType(CategoryType categoryType,CancellationToken cancellationToken )
        {
            return await TableNoTracking.SingleOrDefaultAsync(x => x.Category == categoryType,cancellationToken);
        }

        public Task<bool> IsExistCategory(CategoryType Category, CancellationToken cancellationToken)
        {
            return TableNoTracking.AnyAsync( x=>x.Category== Category);
        }
    }
}
