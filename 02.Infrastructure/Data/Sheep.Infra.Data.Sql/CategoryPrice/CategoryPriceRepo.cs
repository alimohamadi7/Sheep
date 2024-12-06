using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Category.CategoryPrice;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;
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

        public async Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            IQueryable<CategoryPriceEntity> result = TableNoTracking.Where(x => x.IsDeleted == false).
                Include(x=>x.CategoryEntity);
            if (!string.IsNullOrEmpty(trim))
            {
                //result = result.Where(u => u.SheepNumber.Contains(trim));
            }
            int take = 50;
            int skip = (PageId - 1) * take;
            string Addres = "";

            GetCategoryPriceQuery CategoryPriceQuery = new GetCategoryPriceQuery()
            {
                trim = trim,
                CategoryPriceEntities = await result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)

            };

            CategoryPriceQuery.GeneratePagging(result, PageId, take, trim, Addres);
            return CategoryPriceQuery;
        }

        public async Task<IQueryable<CategoryPriceEntity>> GetCategoryByType(CategoryType categoryType,CancellationToken cancellationToken, int PageId=1)
        {
            int take = 20;
            int skip = (PageId - 1) * take;
            var Result = TableNoTracking.Where(x => x.Category == categoryType);
            return Result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }
    }
}
