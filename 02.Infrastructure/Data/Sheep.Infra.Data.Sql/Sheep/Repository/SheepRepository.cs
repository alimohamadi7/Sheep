using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;
using Sheep.Framework.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sheep.Infra.Data.Sql.Sheep.Repository
{
    public class SheepRepository : Repository<SheepEntity>, ISheepRepository
    {
        private readonly SheepDbcontext _context;
        public SheepRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<GetSheepQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            IQueryable<SheepEntity> result = TableNoTracking.Where(x => x.IsDeleted == false 
            &&x.SheepState ==State.present).Include(x=>x.SheepCategories);
            if (!string.IsNullOrEmpty(trim))
            {
                result = result.Where(u => u.SheepNumber.Contains(trim));
            }
            int take = 20;
            int skip = (PageId - 1) * take;
            string Addres = "";

            GetSheepQuery SheepQueryViwe = new GetSheepQuery()
            {
                trim = trim,
                sheepEntities = await result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)

            };

            SheepQueryViwe.GeneratePagging(result, PageId, take, trim, Addres);
            return SheepQueryViwe;
        }

        public async Task<SheepEntity> GetSheepBySheepParentNumber(string sheepId, CancellationToken cancellationToken)
        {
         return  await  TableNoTracking.Where(x=>x.SheepNumber== sheepId).SingleOrDefaultAsync(cancellationToken);

        }

        public IQueryable<SheepEntity> GetsheepForAge(CancellationToken cancellationToken, int PageId = 1)
        {
            IQueryable<SheepEntity> result = TableNoTracking.Where(x => x.IsDeleted == false
            && x.SheepState == State.present);
            int take = 100;
            int skip = (PageId - 1) * take;
            return  result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }

        public async Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken)
        {
            var result =await TableNoTracking.AnyAsync(x => x.SheepNumber == createCommand.SheepNumber,cancellationToken);
            if (result == false)
            {
                return OperationResult<bool>.SuccessResult(true);
            }
            return OperationResult<bool>.FailureResult(createCommand.SheepNumber, ApplicationMessages.DuplicatedRecord);
        }

        public async Task<bool> SheepIsParent(Guid Id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(x => x.ParentId == Id); 
        }
    }
}
