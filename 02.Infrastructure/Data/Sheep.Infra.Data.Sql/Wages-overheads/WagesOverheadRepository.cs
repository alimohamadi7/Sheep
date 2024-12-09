using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Wages_overheads;
using Sheep.Core.Application.Wages_overheads.Contracts;
using Sheep.Core.Domain.Wages_overheads;
using Sheep.Framework.Infrastructure.Data;



namespace Sheep.Infra.Data.Sql.Wages_overheads
{
    public class WagesOverheadRepository : Repository<Wages_overheadsEntity>, IWagesoverheadsRepository
    {
        private readonly SheepDbcontext _context;
        public WagesOverheadRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;

        }

        public async Task<GetWagesOverheadQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, int PageId = 1, string trim = "")
        {
            var Start = Convert.ToDateTime(start.ToGregorianDateTime());
            var End = Convert.ToDateTime(end.ToGregorianDateTime());
            IQueryable<Wages_overheadsEntity> result = TableNoTracking.Where(x => x.IsDeleted == false);
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                result = result.Where(u => (u.Start >= Start && u.End <= End));
            }
            int take = 50;
            int skip = (PageId - 1) * take;
            string Addres = "";

            GetWagesOverheadQuery overheadQuery = new GetWagesOverheadQuery()
            {
                Start = start,
                End = end,
                wagesOverheads = await result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)

            };

            overheadQuery.GeneratePagging_V4(result, PageId, take, Addres, start, end);
            return overheadQuery;
        }


        public async Task<IQueryable<Wages_overheadsEntity>> GetWagesOverheadDate(CancellationToken cancellationToken, int PageId = 1)
        {
            int take = 20;
            int skip = (PageId - 1) * take;
            var Result = TableNoTracking;
            return Result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }
    }
}
