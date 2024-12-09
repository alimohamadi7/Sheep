using DNTPersianUtils.Core;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Wages_overheads.Contracts;
using Sheep.Core.Domain.Wages_overheads;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.Wages_overheads
{
    public class WagesoverheadsApplication : IWagesoverheadsApplication
    {
        private readonly IWagesoverheadsRepository _wagesoverheadsRepository;

        public WagesoverheadsApplication(IWagesoverheadsRepository wagesoverheadsRepository)
        {
            _wagesoverheadsRepository = wagesoverheadsRepository;
        }

        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            var Start = Convert.ToDateTime(command.Start.ToGregorianDateTime());
            var End = Convert.ToDateTime(command.End.ToGregorianDateTime());
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
                    return OperationResult<bool>.FailureResult("", ApplicationMessages.DatePeriodNotValid);

                }
            }
            while (false);
            //Check StartDate not big from End
            if (Start > End)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.InvalidStartDate);
            //Check StartDate not Equal End
            if (Start == End)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.StartDateEqualEndDate);
            //check datarange not to exist
            var CheckDateRage = await CheckDate(Start, End, cancellationToken);
            if (CheckDateRage)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.DuplicateDate);
            var SalaryString = command.Salary.Replace(",", string.Empty);
            var OverheadString = command.Overhead.Replace(",", string.Empty);
            var Salary = Convert.ToInt64(SalaryString);
            var Overhead = Convert.ToInt64(OverheadString);
            Wages_overheadsEntity wages_OverheadsEntity = new Wages_overheadsEntity(Salary, Overhead, Start, End);
            await _wagesoverheadsRepository.AddAsync(wages_OverheadsEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
           var result=await _wagesoverheadsRepository.GetByIdAsync(cancellationToken,id);
            result.Delete();
            await _wagesoverheadsRepository.SaveChangesAsync(cancellationToken);
            return  OperationResult<bool>.SuccessResult(true) ;
        }

        public async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            var Start = Convert.ToDateTime(command.Start.ToGregorianDateTime());
            var End = Convert.ToDateTime(command.End.ToGregorianDateTime());
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
                    return OperationResult<bool>.FailureResult("", ApplicationMessages.DatePeriodNotValid);

                }
            }
            while (false);
            //Check StartDate not big from End
            if (Start > End)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.InvalidStartDate);
            //Check StartDate not Equal End
            if (Start == End)
                return OperationResult<bool>.FailureResult("", ApplicationMessages.StartDateEqualEndDate);
            //check datarange not to exist
            if (Start != command.StartLaste && End != command.EndLaste)
            {
                var CheckDateRage = await CheckDate(Start, End, cancellationToken);
                if (CheckDateRage)
                    return OperationResult<bool>.FailureResult("", ApplicationMessages.DuplicateDate);
            }
            var SalaryString = command.Salary.Replace(",", string.Empty);
            var OverheadString = command.Overhead.Replace(",", string.Empty);
            var Salary = Convert.ToInt64(SalaryString);
            var Overhead = Convert.ToInt64(OverheadString);
            var wagesoverhead=await _wagesoverheadsRepository.GetByIdAsync(cancellationToken,command.Id);
            wagesoverhead.Edit(Salary,Overhead,Start,End);
         await   _wagesoverheadsRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }
        
        public async Task<GetWagesOverheadQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, int pageId = 1)
        {
           return await _wagesoverheadsRepository.GetAll(cancellationToken, start, end, pageId);
        }

        public async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var result=await _wagesoverheadsRepository.GetByIdAsync(cancellationToken,id);
            return new EditCommand()
            {
                Salary= Convert.ToString(result.Salary),
                Overhead= Convert.ToString(result.Overhead),
                Start=result.Start.ToShortPersianDateString(),
                End=result.End.ToShortPersianDateString(),
                EndLaste=result.End,
                StartLaste=result.Start,
            };
        }


        public async Task<bool> CheckDate(DateTime Start, DateTime End, CancellationToken cancellationToken)
        {
            var pageId = 1;
            for (int i = 0; i < pageId; i++)
            {
                var wagesoverheads = await _wagesoverheadsRepository.GetWagesOverheadDate(cancellationToken, pageId);

                foreach (var item in wagesoverheads)
                {
                    DateRange range = new DateRange(item.Start, item.End);
                    if (range.Includes(Start) || range.Includes(End))
                    {
                        return true;
                    }

                    if (wagesoverheads.Any())
                    {
                        pageId++;
                    }
                }
            }
            return false;
        }
    }
}
