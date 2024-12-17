using DNTPersianUtils.Core;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Entity;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CategoryPriceApplication : ICategoryPriceApplication
    {
        private readonly ICategoryPriceRepository _categoryPriceRepository;
        private readonly ICategoryApplication _categoryApplication;
        private readonly ISheepCategoryApplication _sheepCategoryApplication;
        private readonly ISheepPricePeriodApp   _pricePeriodApp;
        public CategoryPriceApplication(ICategoryPriceRepository categoryPriceRepository, ICategoryApplication categoryApplication, ISheepCategoryApplication sheepCategoryApplication, ISheepPricePeriodApp pricePeriodApp)
        {
            _categoryPriceRepository = categoryPriceRepository;
            _categoryApplication = categoryApplication;
            _sheepCategoryApplication = sheepCategoryApplication;
            _pricePeriodApp = pricePeriodApp;
        }

        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            DateTime Start = Convert.ToDateTime(command.Start.ToGregorianDateTime());
            DateTime End = Convert.ToDateTime(command.End.ToGregorianDateTime());
            // Check start and end not less 30 day
            var a = Start.DayOfYear;
            do
            {
                if ((End - Start).TotalDays + 1 < 30)
                {
                    if (Start.DayOfYear == 50 || Start.DayOfYear==51)
                    {
                        break;
                    }
                    return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.DatePeriodNotValid);

                }
            }
            while (false);
            //check category ram not gendertype female
            if (command.Gender == GenderType.Female && command.Category == CategoryType.Ram)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.RamIsnotFemale);
            //check ewe not gendertype male
            if (command.Gender == GenderType.Male && command.Category == CategoryType.Ewe)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.EveIsnotMale);
            //Check StartDate not big from End
            if (Start > End)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.InvalidStartDate);
            //Check StartDate not Equal End
            if (Start == End)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.StartDateEqualEndDate);
            //check datarange not to exist
            var CheckDateRage = await CheckDateForCtegory(command.Category, Start, End, cancellationToken);
            if (CheckDateRage)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.DuplicateDate);
            //End check daterange
            var Foodstring = command.Food.Replace(",", string.Empty);
            var Food = Convert.ToInt64(Foodstring);
            var categoryId = await _categoryApplication.GetCategoryByCategoryType(command.Category, cancellationToken);
            CategoryPriceEntity categoryPriceEntity = new CategoryPriceEntity(Food, command.Gender, command.Category,
                Start, End, categoryId.Id);
            await _categoryPriceRepository.AddAsync(categoryPriceEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);

        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceRepository.GetByIdAsync(cancellationToken, id);
            result.Delete();
            await _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            DateTime Start = Convert.ToDateTime(command.Start.ToGregorianDateTime());
            DateTime End = Convert.ToDateTime(command.End.ToGregorianDateTime());
            // Check start and end not less 30 day
            var a = Start.DayOfYear;
            do
            {
                if ((End - Start).TotalDays + 1 < 30)
                {
                    if (Start.DayOfYear == 50 || Start.DayOfYear == 51)
                    {
                        break;
                    }
                    return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.DatePeriodNotValid);

                }
            }
            while (false);
            //check category ram not gendertype female
            if (command.Gender == GenderType.Female && command.Category == CategoryType.Ram)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.RamIsnotFemale);
            //check ewe not gendertype male
            if (command.Gender == GenderType.Male && command.Category == CategoryType.Ewe)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.EveIsnotMale);
            //Check StartDate not big from End
            if (Start > End)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.InvalidStartDate);
            //Check StartDate not Equal End
            if (Start == End)
                return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.StartDateEqualEndDate);
            //check datarange not to exist
            if (Start != command.StartLaste && End != command.EndLaste)
            {
                var CheckDateRage = await CheckDateForCtegory(command.Category, Start, End, cancellationToken);
                if (CheckDateRage)
                    return OperationResult<bool>.FailureResult(command.Category.ToString(), ApplicationMessages.DuplicateDate);
            }
            //End check daterange
            var categoryId = await _categoryApplication.GetCategoryByCategoryType(command.Category, cancellationToken);
            var Foodstring = command.Food.Replace(",", string.Empty);
            var Food = Convert.ToInt64(Foodstring);
            var result = await _categoryPriceRepository.GetByIdAsync(cancellationToken, command.Id);
            result.Edit(Food, command.Gender, command.Category, Start, End, categoryId.Id);
            await _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, CategoryType category, GenderType gender, int PageId = 1)
        {
            return await _categoryPriceRepository.GetAll(cancellationToken, start, end, category, gender, PageId);
        }

        public async Task<bool> CheckDateForCtegory(CategoryType categoryType, DateTime Start, DateTime End, CancellationToken cancellationToken)
        {
            var pageId = 1;
            for (int i = 0; i < pageId; i++)
            {
                var category = await _categoryPriceRepository.GetCategoryByType(categoryType, cancellationToken, pageId);

                foreach (var item in category)
                {
                    DateRange range = new DateRange(item.Start, item.End);
                    if (range.Includes(Start) || range.Includes(End))
                    {
                        return true;
                    }

                    if (category.Any())
                    {
                        pageId++;
                    }
                }
            }
            return false;
        }

        public async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceRepository.GetByIdAsync(cancellationToken, id);
            return new EditCommand()
            {
                Id = result.Id,
                Category = result.Category,
                CategoryId = result.CategoryId,
                End = result.End.ToShortPersianDateString(),
                Food = Convert.ToString(result.Food),
                Start = result.Start.ToShortPersianDateString(),
                Gender = result.Gender,
                StartLaste = result.Start,
                EndLaste = result.End,
            };
        }

        public async Task<OperationResult<bool>> CalculatedPriceSixEighteen(CalcuteCommand command, CancellationToken cancellationToken)
        {
            int livestockday = 0;
            double PricePerdaySheep = 0;
            var pageId = 1;
            int i = 0;
            SheepCategoryQuery Command = new SheepCategoryQuery()
            { 
            GenderType=command.Gender,
            Start= command.Start,
            End= command.End,
            };
            var SheepSixEighteen =  _sheepCategoryApplication.GetAllSixEighteen(Command, cancellationToken).Count();
            if (SheepSixEighteen == 0)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.NotSheepFuondInRaneDate);
            //calcute livestockday
            for (i = 0; i < pageId; i++)
            {
                var SheepThreesix = _sheepCategoryApplication.GetAllSixEighteen(Command, cancellationToken, pageId);
                foreach (var item in SheepThreesix)
                {
                    var ThreeSixCal = Convert.ToDateTime(item.Three_SixCalcute);
                    var livestockpersheep = Calculate.CalculateDateRange(ThreeSixCal, Command.End);
                    if (livestockpersheep > 360)
                        livestockpersheep = 360;
                    var Sheepcategory = await _sheepCategoryApplication.GetSheepCategoryById(item.Id, cancellationToken);
                    Sheepcategory.Three_SixCalcute = Sheepcategory.Three_SixCalcute.AddDays(livestockpersheep);
                    livestockday = livestockday + livestockpersheep;
                }
                if (SheepThreesix.Any())
                {
                    //await _sheepCategoryApplication.SaveChangeAsync(cancellationToken);
                    pageId++;
                }
                //End calcute livestockday
            }
            //category price update price pership
            var categoryPriceEntity = await _categoryPriceRepository.GetCategoryPriceById(command.Id, cancellationToken);
            if (categoryPriceEntity != null && livestockday != 0)
                PricePerdaySheep = categoryPriceEntity.Food / livestockday;
            categoryPriceEntity.PricePerSheep = PricePerdaySheep;
            categoryPriceEntity.Calculated = true;
            categoryPriceEntity.CountSheep = i;

            //End category price update price pership
            //start sheep price period Calcute
            Sheep.PricePeriod.CreateCommand createCommand = new Sheep.PricePeriod.CreateCommand()
            {
                CategoryPriceId = categoryPriceEntity.Id,
                Gender = command.Gender,
                Start = command.Start,
                End = command.End,
                PricePerSheep = categoryPriceEntity.PricePerSheep,
            };
            await _pricePeriodApp.SixEighteenCreate(createCommand, cancellationToken);
            //End sheep price period Calcute
            await _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> CalculatedPriceThreeSix(CalcuteCommand command, CancellationToken cancellationToken)
        {
            int livestockday = 0;
            double PricePerdaySheep = 0;
            var pageId = 1;
            int i=0;
            SheepCategoryQuery Command = new SheepCategoryQuery()
            {
                GenderType = command.Gender,
                Start = command.Start,
                End = command.End,
            };
            var Sheepthreesix = _sheepCategoryApplication.GetAllThreeSix(Command, cancellationToken, pageId).Count();
            if (Sheepthreesix == 0)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.NotSheepFuondInRaneDate);
            //calcute livestockday
            for (i =0; i < pageId; i++)
            {
                var SheepThreesix =  _sheepCategoryApplication.GetAllThreeSix(Command, cancellationToken,pageId);
                foreach (var item in SheepThreesix)
                {
                    var livestockpersheep = Calculate.CalculateDateRange(item.Three_SixCalcute, Command.End);
                    if (livestockpersheep > 90)
                        livestockpersheep = 90;
                    livestockday = livestockday + livestockpersheep;
                }
                if (SheepThreesix.Any())
                {
                    pageId++;
                }
                //End calcute livestockday
            }
            //category price update price pership
            var categoryPriceEntity=await _categoryPriceRepository.GetCategoryPriceById(command.Id ,cancellationToken);
            if (categoryPriceEntity != null && livestockday != 0)
                PricePerdaySheep = categoryPriceEntity.Food / livestockday; 
            categoryPriceEntity.PricePerSheep= PricePerdaySheep;
            categoryPriceEntity.Calculated = true;
            categoryPriceEntity.CountSheep =i+1;

            //End category price update price pership
            //start sheep price period Calcute
            Sheep.PricePeriod.CreateCommand createCommand = new Sheep.PricePeriod.CreateCommand()
            {
                CategoryPriceId = categoryPriceEntity.Id,
                Gender = command.Gender,
                Start = command.Start,
                End = command.End,
                PricePerSheep = categoryPriceEntity.PricePerSheep,
            };
                  await    _pricePeriodApp.ThreeSixCreate(createCommand, cancellationToken);
            //End sheep price period Calcute
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<CategoryPriceEntity> GetCategoryPriceById(Guid Id, CancellationToken cancellationToken)
        {
           return await _categoryPriceRepository.GetCategoryPriceById(Id, cancellationToken);  
        }

        public async Task<CalcuteCommand> GetDetailsForCalcute(Guid id, CancellationToken cancellationToken)
        {
           return await  _categoryPriceRepository.GetDetailsForCalcute(id, cancellationToken);
        }
    }
}
