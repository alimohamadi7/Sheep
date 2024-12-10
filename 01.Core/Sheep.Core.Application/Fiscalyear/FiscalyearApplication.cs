using DNTPersianUtils.Core;
using Sheep.Core.Application.Fiscalyear.Contracts;
using Sheep.Core.Domain.Fiscalyear;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Fiscalyear
{
    public class FiscalyearApplication : IFiscalyearApplication
    {
        private readonly IFiscalyearRepository _repository;

        public FiscalyearApplication(IFiscalyearRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
           var Start=Convert.ToDateTime(command.Start.ToGregorianDateTime());
            var End=Convert.ToDateTime( command.End.ToGregorianDateTime());
            var StartPersian = command.Start.ToGregorianDateOnly();
            var EndPersian= command.End.ToGregorianDateOnly();
            if (Start==End || Start > End )
                return OperationResult<bool>.FailureResult("", ApplicationMessages.DatePeriodNotValid);
            var persianYear = DateTime.Now.GetPersianYearStartAndEndDates();
            if( (StartPersian!=persianYear.StartDateOnly)|| (EndPersian !=persianYear.EndDateOnly))
                return OperationResult<bool>.FailureResult("", ApplicationMessages.DatePeriodNotValid);
            var result = await _repository.GetLastFiscalYear(cancellationToken);

            if (result != null)
            { 
                    if ( result.Start.ToShortDateString() == Start.ToShortDateString() && result.End.ToShortDateString() ==End.ToShortDateString() )
                        return OperationResult<bool>.FailureResult("", ApplicationMessages.NotFisCalYearValid);
                else
                {
                    result.IsActive = false;
                }
            }
     
            FiscalyearEntity fiscalyearEntity = new FiscalyearEntity(Start, End);
         await   _repository.AddAsync(fiscalyearEntity,cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result=await _repository.GetByIdAsync(cancellationToken, id);
            result.Delete();
        await    _repository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<GetFiscalyearQuery> GetAll(CancellationToken cancellationToken)
        {
        return   await _repository.GetAll(cancellationToken);
        }

        public async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(cancellationToken, id);
            return new EditCommand()
            {
                Id= result.Id,

            };
        }
    }
}
