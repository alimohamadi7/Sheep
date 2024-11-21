
using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.SheepBirth.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.SheepBirth

{
    public class SheepBirthRepository : Repository<SheepEntity>, ISheepBirthRepository
    {
        private readonly SheepDbcontext _context;
        public SheepBirthRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async  Task<GetSheepQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            IQueryable<SheepEntity> result = TableNoTracking.Where(x => x.IsDeleted == false && x.ParentId !=null);
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

        public async Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken)
        {
            var result = TableNoTracking.Any(x => x.SheepNumber == createCommand.SheepNumber);
            if (result == false)
            {
                return OperationResult<bool>.SuccessResult(true);
            }
            return OperationResult<bool>.FailureResult(createCommand.SheepNumber, ApplicationMessages.DuplicatedRecord);
        }

    }
}
