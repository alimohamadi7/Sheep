using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;

namespace Sheep.Core.Application.Sheep.PricePeriod
{
    public class SheepPricePeriodApp : ISheepPricePeriodApp
    {
        private readonly ISheepPricePeriodRepo _sheepPricePeriodRepo;
        private readonly ISheepCategoryApplication _sheepCategoryApplication;
        public SheepPricePeriodApp(ISheepPricePeriodRepo sheepPricePeriodRepo, ISheepCategoryApplication sheepCategoryApplication)
        {
            _sheepPricePeriodRepo = sheepPricePeriodRepo;
            _sheepCategoryApplication = sheepCategoryApplication;
        }

        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            SheepCategoryQuery Command = new SheepCategoryQuery()
            {
                GenderType = command.Gender,
                Start = command.Start,
                End = command.End,
            };
            var pageId = 1;
            for (int i = 0; i < pageId; i++)
            {
                var SheepThreesix = _sheepCategoryApplication.GetAllThreeSix(Command, cancellationToken, pageId);

            }
            SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(command.PriceSheep,command.Unabsorbedcosts,command.Start,command.End);
           await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity,cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
