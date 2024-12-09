﻿using DNTPersianUtils.Core;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CategoryPriceApplication : ICategoryPriceApplication
    {
        private readonly ICategoryPriceRepository _categoryPriceRepository;
        private readonly ICategoryApplication _categoryApplication;
        public CategoryPriceApplication(ICategoryPriceRepository categoryPriceRepository, ICategoryApplication categoryApplication)
        {
            _categoryPriceRepository = categoryPriceRepository;
            _categoryApplication = categoryApplication;
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
    }
}
