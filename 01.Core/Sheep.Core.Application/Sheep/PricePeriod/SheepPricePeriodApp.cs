using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;

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
                var SheepThreesix = _sheepCategoryApplication.GetAllThreeSixForPricePeriod(Command, cancellationToken, pageId);
                foreach (var item in SheepThreesix)
                {
                    var day = Calculate.CalculateDateRange(item.Start_Three_Six, item.Three_SixCalcute);
                    command.PriceSheep=Convert.ToInt64( command.PricePerSheep*day);
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(command.PriceSheep, command.Unabsorbedcosts, command.Start, command.End);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    // to do find sheep in  full price  and update or  create new 
                    //add new relation for perice period entity  white sheep and category price
                }
                if (SheepThreesix.Any())
                {
                    pageId++;
                }
            }
           
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
