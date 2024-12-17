using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepFullPrice.Contracts;
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
        private readonly IFullPriceSheepApplication _fullPriceSheepApplication;
        public SheepPricePeriodApp(ISheepPricePeriodRepo sheepPricePeriodRepo, ISheepCategoryApplication sheepCategoryApplication, IFullPriceSheepApplication fullPriceSheepApplication)
        {
            _sheepPricePeriodRepo = sheepPricePeriodRepo;
            _sheepCategoryApplication = sheepCategoryApplication;
            _fullPriceSheepApplication = fullPriceSheepApplication;
        }

        public async Task<OperationResult<bool>> SixEighteenCreate(CreateCommand command, CancellationToken cancellationToken)
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
                var SheepThreesix = _sheepCategoryApplication.GetAllSixEighteenForPricePeriod(Command, cancellationToken, pageId);
                foreach (var item in SheepThreesix)
                {
                    var day = Calculate.CalculateDateRange(item.Start_Three_Six, item.Three_SixCalcute);
                    command.PriceSheep = Convert.ToInt64(command.PricePerSheep * day);
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(item.SheepId, command.CategoryPriceId, command.PriceSheep, command.Unabsorbedcosts, command.Start, command.End, item.Three_SixCalcute);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    //start to do find sheep in  Sheepfull price  and update or  create new
                    var sheepFullPrice = await _fullPriceSheepApplication.GetSheepBySheepId(item.SheepId, cancellationToken);
                    if (sheepFullPrice != null)
                    {
                        sheepFullPrice.PriceSheep = sheepFullPrice.PriceSheep + command.PriceSheep;
                        sheepFullPrice.Edit(sheepFullPrice.PriceSheep, command.Unabsorbedcosts, sheepFullPrice.SheepId, item.Three_SixCalcute);
                    }
                    else
                    {
                        SheepFullPrice.CreateCommand createCommand = new SheepFullPrice.CreateCommand()
                        {
                            Calcuted = item.Three_SixCalcute,
                            PriceSheep = command.PriceSheep,
                            SheepId = item.SheepId,
                            Unabsorbedcosts = command.Unabsorbedcosts,
                        };
                        await _fullPriceSheepApplication.Create(createCommand, cancellationToken);
                    }
                    //End to do find sheep in  Sheepfull price  and update or  create new
                }
                if (SheepThreesix.Any())
                {
                    pageId++;
                }
            }

            return OperationResult<bool>.SuccessResult(true);
        }


        public async Task<OperationResult<bool>> ThreeSixCreate(CreateCommand command, CancellationToken cancellationToken)
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
                foreach (var item in SheepThreesix)
                {
                    var day = Calculate.CalculateDateRange(item.Three_SixCalcute, command.End);
                    if (day > 90)
                        day = 90;
                    command.PriceSheep=Convert.ToInt64( command.PricePerSheep*day);
                    var Sheepcategory = await _sheepCategoryApplication.GetSheepCategoryById(item.Id, cancellationToken);
                    Sheepcategory.Three_SixCalcute = Sheepcategory.Three_SixCalcute.AddDays(day);
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(item.SheepId,command.CategoryPriceId,command.PriceSheep, command.Unabsorbedcosts, command.Start, command.End, item.Three_SixCalcute);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    //start to do find sheep in  Sheepfull price  and update or  create new
                  var sheepFullPrice= await _fullPriceSheepApplication.GetSheepBySheepId(item.SheepId, cancellationToken);
                    if(sheepFullPrice != null)
                    {
                        sheepFullPrice.PriceSheep = sheepFullPrice.PriceSheep + command.PriceSheep;
                        sheepFullPrice.Edit(sheepFullPrice.PriceSheep, command.Unabsorbedcosts, sheepFullPrice.SheepId, item.Three_SixCalcute);
                    }
                    else
                    {
                        SheepFullPrice.CreateCommand createCommand =new SheepFullPrice.CreateCommand()
                        {
                             Calcuted=item.Three_SixCalcute,
                             PriceSheep= command.PriceSheep,
                             SheepId= item.SheepId,
                             Unabsorbedcosts= command.Unabsorbedcosts,
                        };
                    await   _fullPriceSheepApplication.Create(createCommand ,  cancellationToken);
                    }
                    //End to do find sheep in  Sheepfull price  and update or  create new
                }
                if (SheepThreesix.Any())
                {
                    pageId++;
                }
            }
        await   _sheepPricePeriodRepo.SaveChangesAsync(cancellationToken);   
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
