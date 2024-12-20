﻿
using Microsoft.EntityFrameworkCore;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Infrastructure.Data;

namespace Sheep.Infra.Data.Sql.Sheep.SheepCategory
{
    public class SheepCategoryRepository : Repository<SheepCategoryEntity>, ISheepCategoryRepository
    {
        private readonly SheepDbcontext _context;
        public SheepCategoryRepository(SheepDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<GetSheepCategoryQuery>> GetAll(Guid SheepId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(x => x.SheepId == SheepId)
                      .Select(x => new GetSheepCategoryQuery { id = x.Id }).ToListAsync(cancellationToken);

        }

        public IQueryable<SheepCategoryEntity> GetAllThreeSix(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1)
        {
            var result = TableNoTracking.Where(x => x.Gender == Command.GenderType && x.IsDeleted == false && x.Three_SixCalcute < x.End_Three_Six && x.Three_SixCalcute >= Command.Start);
            int take = 100;
            int skip = (PageId - 1) * take;
            return result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }

        public IQueryable<SheepCategoryEntity> GetAllThreeSixForPricePeriod(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1)
        {
            var result = TableNoTracking.Where(x => x.Gender == Command.GenderType && x.IsDeleted == false && x.Three_SixCalcute == Command.End);
            int take = 100;
            int skip = (PageId - 1) * take;
            return result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);

        }

        public  IQueryable<SheepCategoryEntity> GetAllSixEighteen(SheepCategoryQuery Command, CancellationToken cancellationToken ,int PageId = 1)
        {
            int take = 100;
            int skip = (PageId - 1) * take;

            var result = TableNoTracking.Where(x => x.Gender == Command.GenderType && x.IsDeleted == false && x.Six_EighteenCalcute < x.End_Six_Eighteen && x.Six_EighteenCalcute >= Command.Start);
            return result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);
        }

        public async Task<int> GetCount()
        {
            return TableNoTracking.Count();
        }

        public Task<SheepCategoryEntity> GetSheepCategoryBySheepId(Guid Id, CancellationToken cancellationToken)
        {
            return Table.SingleOrDefaultAsync(x => x.SheepId == Id, cancellationToken);
        }

        public IQueryable<SheepCategoryEntity> GetsheepForCategory(CancellationToken cancellationToken, int PageId)
        {
            IQueryable<SheepCategoryEntity> result = TableNoTracking.Where(x => x.IsDeleted == false);
            int take = 100;
            int skip = (PageId - 1) * take;
            return result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);
        }

        public IQueryable<SheepCategoryEntity> GetAllSixEighteenForPricePeriod(SheepCategoryQuery Command, CancellationToken cancellationToken, int PageId = 1)
        {

            var result = TableNoTracking.Where(x => x.Gender == Command.GenderType && x.IsDeleted == false && x.Six_EighteenCalcute == Command.End);
            int take = 100;
            int skip = (PageId - 1) * take;
            return result.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take);
        }
    }
}
