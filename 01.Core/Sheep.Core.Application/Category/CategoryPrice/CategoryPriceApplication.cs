using DNTPersianUtils.Core;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.Contracts;

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
        public CategoryPriceApplication(ICategoryPriceRepository categoryPriceRepository, ICategoryApplication categoryApplication, ISheepCategoryApplication sheepCategoryApplication)
        {
            _categoryPriceRepository = categoryPriceRepository;
            _categoryApplication = categoryApplication;
            _sheepCategoryApplication = sheepCategoryApplication;
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

        public async Task<OperationResult<bool>> CalculatedPriceZeroThree(CalcuteCommand command, CancellationToken cancellationToken)
        {
            SheepCategoryQuery Command = new SheepCategoryQuery()
            { 
            GenderType=command.Gender,
            Start= command.Start,
            End= command.End,
            };
            var SheepZeroThree = await _sheepCategoryApplication.GetAllZeroThree(Command, cancellationToken);
            foreach (var item in SheepZeroThree)
            {

            }
            //var livestockday=
            throw new NotImplementedException();
        }

        public async Task<OperationResult<bool>> CalculatedPriceThreeSix(CalcuteCommand command, CancellationToken cancellationToken)
        {
            SheepCategoryQuery Command = new SheepCategoryQuery()
            {
                GenderType = command.Gender,
                Start = command.Start,
                End = command.End,
            };
            var SheepThreesix = _sheepCategoryApplication.GetAllThreeSix(Command, cancellationToken);
            int livestockday = 0;
            long PricePerdaySheep = 0;
            foreach (var item in SheepThreesix)
            {
                var ThreeSixCal = Convert.ToDateTime(item.Three_SixCalcute);
                var livestockpersheep = Calculate.Calculatelivestockday(ThreeSixCal);
                var Sheepcategory =await _sheepCategoryApplication.GetSheepCategoryById(item.CategoryId, cancellationToken);
                Sheepcategory.Three_SixCalcute = Sheepcategory.Three_SixCalcute.AddDays(livestockpersheep);
                livestockday = livestockday + livestockpersheep;
            }
            var categoryPriceEntity=await _categoryPriceRepository.GetCategoryPriceById(command.Id ,cancellationToken);
            if (categoryPriceEntity != null && livestockday != 0)
                PricePerdaySheep = categoryPriceEntity.Food / livestockday;
            categoryPriceEntity.PricePerSheep= PricePerdaySheep;
            categoryPriceEntity.Calculated = true;
           await _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            throw new NotImplementedException();
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
