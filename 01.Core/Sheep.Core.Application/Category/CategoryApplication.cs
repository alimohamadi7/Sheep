using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;


namespace Sheep.Core.Application.Category
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _repository;
        public CategoryApplication(ICategoryRepository repository) 
        { 
            _repository = repository; 
        }
        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            CategoryEntity categoryEntity = new CategoryEntity(command.Name,
                command.Gender)
        ;
            await _repository.AddAsync(categoryEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public Task<OperationResult<bool>> Delete(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EditCommand>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken)
        {
            return  await   _repository.GetAll(cancellationToken);
      

        }

        public Task<OperationResult<EditCommand>> GetDetails(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
