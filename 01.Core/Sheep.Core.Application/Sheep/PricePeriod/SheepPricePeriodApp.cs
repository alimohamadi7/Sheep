﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sheep.Core.Application.Sheep.Contracts;
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
        private readonly ISheepApplication _sheepApplication;
        public SheepPricePeriodApp(ISheepPricePeriodRepo sheepPricePeriodRepo, ISheepCategoryApplication sheepCategoryApplication, 
            IFullPriceSheepApplication fullPriceSheepApplication)
        {
            _sheepPricePeriodRepo = sheepPricePeriodRepo;
            _sheepCategoryApplication = sheepCategoryApplication;
            _fullPriceSheepApplication = fullPriceSheepApplication;
        }

        public async Task<OperationResult<bool>> EweCreate(CreateCommand command, CancellationToken cancellationToken)
        {
            SheepCategoryQuery Command = new SheepCategoryQuery()
            {
                GenderType = command.Gender,
                Start = command.Start,
                End = command.End,
            };
            var pageId = 1;
            int day = 0;
            for (int i = 0; i < pageId; i++)
            {
                var SheepEwe = _sheepCategoryApplication.GetAllEwe(Command, cancellationToken, pageId);
                foreach (var item in SheepEwe)
                {
                        day = Calculate.CalculateDateRange(item.Ram_EweCalcute, Command.End);
                    var Sheepcategory = await _sheepCategoryApplication.GetSheepCategoryById(item.Id, cancellationToken);
                    Sheepcategory.Ram_EweCalcute = Sheepcategory.Ram_EweCalcute.AddDays(day);
                    command.PriceSheep = command.PricePerSheep * day;
                    //Start calcute price child
               if(await _sheepApplication.IsExistSheepchild(item.SheepId, command.Start, command.End, cancellationToken))
                    {

                        command.PriceSheep = 0;
                    }
                    else
                    {
                        command.Unabsorbedcosts = command.PriceSheep;
                        command.PriceSheep = 0;
                    }
                    //End calcute price  child
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(item.SheepId,
                        command.CategoryPriceId,
                        command.PriceSheep, command.Unabsorbedcosts,
                        command.Start, command.End, item.Three_SixCalcute);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    //start to do find sheep in  Sheepfull price  and update or  create new
                    var sheepFullPrice = await _fullPriceSheepApplication.GetSheepBySheepId(item.SheepId, cancellationToken);
                    if (sheepFullPrice != null)
                    {
                        sheepFullPrice.PriceSheep = sheepFullPrice.PriceSheep + command.PriceSheep;
                        sheepFullPrice.Edit(sheepFullPrice.PriceSheep, command.Unabsorbedcosts,
                            sheepFullPrice.SheepId, item.Three_SixCalcute);
                    }
                    else
                    {
                        SheepFullPrice.CreateCommand createCommand = new SheepFullPrice.CreateCommand()
                        {
                            Calcuted = item.Ram_EweCalcute,
                            PriceSheep = command.PriceSheep,
                            SheepId = item.SheepId,
                            Unabsorbedcosts = command.Unabsorbedcosts,
                        };
                        await _fullPriceSheepApplication.Create(createCommand, cancellationToken);
                    }
                    //End to do find sheep in  Sheepfull price  and update or  create new
                }
                if (SheepEwe.Any())
                {
                    pageId++;
                }
            }
            await _sheepPricePeriodRepo.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<OperationResult<bool>> RamCreate(CreateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
            int day = 0;
            for (int i = 0; i < pageId; i++)
            {
                var SheepThreesix = _sheepCategoryApplication.GetAllSixEighteen(Command, cancellationToken, pageId);
                foreach (var item in SheepThreesix)
                {
                    if (item.End_Six_Eighteen <= command.End)
                        day = Calculate.CalculateDateRange(item.Six_EighteenCalcute, item.End_Six_Eighteen);
                    else
                        day = Calculate.CalculateDateRange(item.Six_EighteenCalcute, Command.End);
                    var Sheepcategory = await _sheepCategoryApplication.GetSheepCategoryById(item.Id, cancellationToken);
                    Sheepcategory.Three_SixCalcute = Sheepcategory.Three_SixCalcute.AddDays(day);
                    command.PriceSheep = command.PricePerSheep * day;
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(item.SheepId,
                        command.CategoryPriceId,
                        command.PriceSheep, command.Unabsorbedcosts, command.Start, 
                        command.End, item.Three_SixCalcute);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    //start to do find sheep in  Sheepfull price  and update or  create new
                    var sheepFullPrice = await _fullPriceSheepApplication.GetSheepBySheepId(item.SheepId, cancellationToken);
                    if (sheepFullPrice != null)
                    {
                        sheepFullPrice.PriceSheep = sheepFullPrice.PriceSheep + command.PriceSheep;
                        sheepFullPrice.Edit(sheepFullPrice.PriceSheep, command.Unabsorbedcosts, 
                            sheepFullPrice.SheepId, item.Three_SixCalcute);
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
            await _sheepPricePeriodRepo.SaveChangesAsync(cancellationToken);
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
            int day = 0;
            for (int i = 0; i < pageId; i++)
            {
                var SheepThreesix = _sheepCategoryApplication.GetAllThreeSix(Command, cancellationToken, pageId);
                foreach (var item in SheepThreesix)
                {
                    if (item.End_Three_Six <= command.End)
                        day = Calculate.CalculateDateRange(item.Three_SixCalcute, item.End_Three_Six);
                    else
                        day = Calculate.CalculateDateRange(item.Three_SixCalcute, Command.End);
                    command.PriceSheep = command.PricePerSheep * day;
                    var Sheepcategory = await _sheepCategoryApplication.GetSheepCategoryById(item.Id, cancellationToken);
                    Sheepcategory.Three_SixCalcute = Sheepcategory.Three_SixCalcute.AddDays(day);
                    SheepPricePeriodEntity sheepPricePeriodEntity = new SheepPricePeriodEntity(item.SheepId, command.CategoryPriceId,
                        command.PriceSheep, command.Unabsorbedcosts, command.Start, command.End, item.Three_SixCalcute);
                    await _sheepPricePeriodRepo.AddAsync(sheepPricePeriodEntity, cancellationToken, false);
                    //start to do find sheep in  Sheepfull price  and update or  create new
                    var sheepFullPrice = await _fullPriceSheepApplication.GetSheepBySheepId(item.SheepId, cancellationToken);
                    if (sheepFullPrice != null)
                    {
                        sheepFullPrice.PriceSheep = sheepFullPrice.PriceSheep + command.PriceSheep;
                        sheepFullPrice.Edit(sheepFullPrice.PriceSheep, command.Unabsorbedcosts, 
                            sheepFullPrice.SheepId, item.Three_SixCalcute);
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
            await _sheepPricePeriodRepo.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
