



using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public interface ICategoryPriceApplication
    {
        Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, string? start, string? end, CategoryType category, GenderType gender, int PageId = 1);
        Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken);
        Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<bool>> CalculatedPriceZeroThree(CalcuteCommand command, CancellationToken cancellationToken);
        Task<OperationResult<bool>> CalculatedPriceThreeSix(CalcuteCommand command, CancellationToken cancellationToken);

    }
}
