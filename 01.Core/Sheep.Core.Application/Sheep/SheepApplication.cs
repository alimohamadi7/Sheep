using DNTPersianUtils.Core;
using Sheep.Core.Application.Background;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Sheep
{
    public class SheepApplication : ISheepApplication
    {
        private readonly ISheepRepository _sheepRepository;
        private readonly ISheepCategoryApplication _sheepCategoryApplication;
        private readonly IBackgroundJobs _backgroundJob;
        public SheepApplication(ISheepRepository sheepRepository, ISheepCategoryApplication sheepCategoryApplication, IBackgroundJobs backgroundJob)
        {
            _sheepRepository = sheepRepository;
            _sheepCategoryApplication = sheepCategoryApplication;
            _backgroundJob = backgroundJob;
        }
        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {   
            var SheepBirthDate = Convert.ToDateTime(command.SheepbirthDate.ToGregorianDateTime());
            var SheepShopDate= command.SheepshopDate.ToGregorianDateTime();
            //check sheepshop not smaller birthdate
            if (command.SheepshopDate !=null && SheepShopDate< SheepBirthDate)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidShopDate);

            }
            //check birthdate not larger from today
            if (SheepBirthDate>DateTime.Now || SheepShopDate>DateTime.Now)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidSheepBirthdate);

            }
            if (await _sheepRepository.Exists(x => x.SheepNumber == command.SheepNumber))
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.DuplicatedRecord);
            if (command.SheepParentId != null)
            {

                if (!await _sheepRepository.Exists(x => x.SheepNumber == command.SheepParentId))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSheepFound);
                var sheepEntity = await _sheepRepository.GetSheepBySheepParentNumber(command.SheepParentId, cancellationToken);
                if (sheepEntity.Gender == GenderType.Male)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepMale);
                }
                if (sheepEntity.SheepSellDate != null || sheepEntity.SheepwastedDate != null)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepParentnotvalid);

                }
                //check age sheep parent
               if (sheepEntity.Age<541)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepParentAge);

                }
                command.ParentId = sheepEntity.Id;
            }
            int age = Calculate.CalculateAge(SheepBirthDate);
            SheepEntity entity = new SheepEntity(command.SheepNumber, SheepBirthDate,
                SheepShopDate, command.ParentId, command.SheepState, command.Gender, age);
            await _sheepRepository.AddAsync(entity, cancellationToken);
            var createSheepcategorCommand = new CreateSheepCategoryCommand()
            {
                SheepId = entity.Id,
                Age = entity.Age,
                Gender = entity.Gender,
                Birthdate = entity.SheepbirthDate,
                SheepshopDate = SheepShopDate
            };
            //add sheepcategory
            if (!_sheepCategoryApplication.Create(createSheepcategorCommand, cancellationToken).Result.isSuccedded)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.AddSheepCategoryError);
            }
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var sheep = await _sheepRepository.GetByIdAsync(cancellationToken, id);
            sheep.Delete();
            await _sheepRepository.SaveChangesAsync( cancellationToken);
            await _sheepCategoryApplication.Delete(sheep.Id,cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            var SheepBirthDate = Convert.ToDateTime(command.SheepbirthDate.ToGregorianDateTime());
            var SheepShopDate =  command.SheepshopDate.ToGregorianDateTime();

            //check sheepshop not smaller birthdate
            if (command.SheepshopDate != null && SheepShopDate < SheepBirthDate)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidShopDate);

            }
            //check birthdate not larger from today
            if (SheepBirthDate > DateTime.Now || SheepShopDate > DateTime.Now)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidSheepBirthdate);

            }
            if ((command.PastSheepNumber != command.SheepNumber))
            {
                //check sheep mother is exists
                if (await _sheepRepository.Exists(x => x.SheepNumber == command.SheepNumber))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.DuplicatedRecord);
            }
            if (command.SheepParentId != null)
            {

                //check sheep mother is exists
                if (!await _sheepRepository.Exists(x => x.SheepNumber == command.SheepParentId))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSheepFound);
                var sheepEntity = await _sheepRepository.GetSheepBySheepParentNumber(command.SheepParentId, cancellationToken);
                //not add child for gender male
                if (sheepEntity.Gender == GenderType.Male)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepMale);
                }
                //check sheepparent is not sell or wasted
                if (sheepEntity.SheepSellDate != null || sheepEntity.SheepwastedDate != null)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepParentnotvalid);

                }
                //check age sheep parent
                if (sheepEntity.Age < 541)
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepParentAge);

                }
                command.ParentId = sheepEntity.Id;
                //check not same sheepnumber and sheepMothernumber
                if (CheckSameSheepNumberandMotherNumber(command.SheepNumber, command.SheepParentId))
                {
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotSameNumber);

                }
            }
            //check sheep has child gender not change to male
            if (await _sheepRepository.SheepIsParent(command.Id, cancellationToken) && (command.Gender == GenderType.Male))
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SheepIsParentNotMale);

            }


            var sheep = await _sheepRepository.GetByIdAsync(cancellationToken, command.Id);
            //check not add new sheepid and lastsheepid add to sheepmother
            if (sheep.Id == command.ParentId)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotChangeAble);

            }
            //Check if sheep Price Calcuted not allow change birthday or Gendertype
                if (await _sheepCategoryApplication.CheckCaluteCategoryPeriod(sheep.Id, cancellationToken))
                    return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.NotChangeAble);
            int age = Calculate.CalculateAge(SheepBirthDate);
            sheep.Edit(command.SheepNumber,
                SheepBirthDate, SheepShopDate, command.ParentId, command.SheepState, command.Gender,age);
            //Edit SheepCategory
            var EditsheepCategorCommand = new EditSheepCategoryCommand()
            {
                SheepId = command.Id,
                Age = age,
                Gender = command.Gender,
                Birthdate = SheepBirthDate,
                SheepshopDate=SheepShopDate,
            };
            if (!_sheepCategoryApplication.Edit(EditsheepCategorCommand, cancellationToken).Result.isSuccedded)
            {
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.AddSheepCategoryError);
            }
        
            await _sheepRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<GetSheepQuery> GetAllSheep(CancellationToken cancellationToken, int pageId = 1, string trim = "")
        {
            return await _sheepRepository.GetAll(cancellationToken, pageId, trim);
        }

        public async Task<OperationResult<bool>> IsExistSheep(CreateCommand createCommand, CancellationToken cancellationToken)
        {
            return await _sheepRepository.IsExistSheep(createCommand, cancellationToken);
        }

        public async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var sheep = await _sheepRepository.GetByIdAsync(cancellationToken, id);
            EditCommand editCommand = new EditCommand()
            {
                Id = sheep.Id,
                SheepbirthDate = sheep.SheepbirthDate.ToShortPersianDateString(),
                LastSheepbirthDate= sheep.SheepbirthDate.ToShortPersianDateString(),
                SheepNumber = sheep.SheepNumber,
                SheepSellDate = sheep.SheepSellDate.ToShortPersianDateString(),
                SheepshopDate = sheep.SheepshopDate.ToShortPersianDateString(),
                SheepwastedDate = sheep.SheepwastedDate.ToShortPersianDateString(),
                SheepState = sheep.SheepState,
                Gender = sheep.Gender,
                LastGender=sheep.Gender,
                ParentId = sheep.ParentId,
                PastSheepNumber = sheep.SheepNumber,
            };
            if (sheep.ParentId != null)
            {
                SheepEntity entity = await _sheepRepository.GetByIdAsync(cancellationToken, sheep.ParentId);
                editCommand.SheepParentId = entity.SheepNumber;
            }
            return editCommand;
        }

        public bool CheckSameSheepNumberandMotherNumber(string sheepnumber, string? sheepmothernunber)
        {
            var result = false;
            if (sheepnumber == sheepmothernunber) result = true;
            return result;

        }

        public async Task CalculateAge(CancellationToken cancellationToken)
        {
            var pageId = 1;
            for (int i = 0; i < pageId; i++)
            {
                IQueryable<SheepEntity> sheep = _sheepRepository.GetsheepForAge(cancellationToken, pageId);
                foreach (var item in sheep)
                {
                    int age = Calculate.CalculateAge(Convert.ToDateTime(Convert.ToDateTime(item.SheepbirthDate)));
                    var entity = await _sheepRepository.GetByIdAsync(cancellationToken, item.Id);
                    entity.Age = age;
                }
                if (sheep.Any())
                {
                    await _sheepRepository.SaveChangesAsync(cancellationToken);
                    pageId++;
                }

            }

        }

        public async Task<OperationResult<bool>> EditSell(EditCommand command, CancellationToken cancellationToken)
        {
            var sheep = await _sheepRepository.GetByIdAsync(cancellationToken, command.Id);
            var SheepSellDate = Convert.ToDateTime( command.SheepSellDate.ToGregorianDateTime());
            var SheepWastedDate = Convert.ToDateTime( command.SheepwastedDate.ToGregorianDateTime());
            if(command.SheepSellDate !=null && SheepSellDate < sheep.SheepbirthDate)
             return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.SellDatesmallBirthdate);
            if (command.SheepwastedDate != null && SheepWastedDate < sheep.SheepbirthDate)
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.WastedDatesmallBirthdate);
            if(command.SheepSellDate != null && SheepSellDate>DateTime.Now)
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidSellDate);
            if (command.SheepwastedDate != null && SheepWastedDate >DateTime.Now)
                return OperationResult<bool>.FailureResult(command.SheepNumber, ApplicationMessages.InvalidWastedDate); 
                sheep.SheepState = command.SheepState;
                sheep.IsDeleted = true;
            if (command.SheepState == State.Sell)
            {
                sheep.SheepSellDate =SheepSellDate;
                return await _sheepCategoryApplication.CalcuteSellOrWastedDate(sheep.Id,SheepSellDate, cancellationToken);
            }
            if (command.SheepState == State.wasted)
            {
                sheep.SheepwastedDate = SheepWastedDate;
                return await _sheepCategoryApplication.CalcuteSellOrWastedDate(sheep.Id, SheepWastedDate, cancellationToken);
            }
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<bool> IsExistSheepchild(Guid SheepId, DateTime Start, DateTime End, CancellationToken cancellationToken)
        {
            return _sheepRepository.IsExistSheepchild(SheepId ,Start,End,cancellationToken);
        }

        public int GetSheepCount(CancellationToken cancellationToken)
        {
            return _sheepRepository.GetSheepCount(cancellationToken);
        }
    }

}
