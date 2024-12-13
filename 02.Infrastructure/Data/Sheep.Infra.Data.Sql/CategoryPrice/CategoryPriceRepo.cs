using DNTPersianUtils.Core;
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

        public async Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, CategoryType category, GenderType gender, int PageId = 1)
        {
            var Start = Convert.ToDateTime(start.ToGregorianDateTime());
            var End = Convert.ToDateTime(end.ToGregorianDateTime());
            IQueryable<CategoryPriceEntity> result = TableNoTracking.Where(x => x.IsDeleted == false);
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                result = result.Where(u =>( u.Start>=Start && u.End<=End) && u.Category==category &&u.Gender==gender);
            }
            int take = 50;
            int skip = (PageId - 1) * take;
            string Addres = "";

            GetCategoryPriceQuery CategoryPriceQuery = new GetCategoryPriceQuery()
            {
                Start=start,
                End=end,
                Category=category,
                Gender=gender,
                CategoryPriceEntities = await result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)

            };

            CategoryPriceQuery.GeneratePagging_V3(result, PageId,take, Addres,start,end,gender,category);
            return CategoryPriceQuery;
        }

        public async Task<CategoryPriceEntity> GetCategoryPriceById(Guid Id, CancellationToken cancellationToken)
        {
            return await Table.SingleOrDefaultAsync(x => x.Id==Id,cancellationToken);
        }

        public async Task<IQueryable<CategoryPriceEntity>> GetCategoryByType(CategoryType categoryType,CancellationToken cancellationToken, int PageId=1)
        {
            int take = 20;
            int skip = (PageId - 1) * take;
            var Result = TableNoTracking.Where(x => x.Category == categoryType);
            return Result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }

        public async Task<CategoryPriceEntity> GetSheepCategoryBySheepId(Guid Id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleOrDefaultAsync(x => x.Id == Id, cancellationToken);

        }

        public async Task<CalcuteCommand> GetDetailsForCalcute(Guid id, CancellationToken cancellationToken)
        {
            var result=await TableNoTracking.SingleOrDefaultAsync(x=>x.Id== id, cancellationToken);
            return new CalcuteCommand() 
            {
                Id=result.Id,
                CategoryId=result.CategoryId,
                Start=result.Start,
                End=result.End,
                Gender=result.Gender,

            };
        }
    }
}
