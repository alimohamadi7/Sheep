using Sheep.Core.Application.CategoryPrice.Contracts;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.CategoryPrice
{
    public class CategoryPriceApp : ICategoryPriceApp
    {
        public Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<GetQouery>> GetAllCategory(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
