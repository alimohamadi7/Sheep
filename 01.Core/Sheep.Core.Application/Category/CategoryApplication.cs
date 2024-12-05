using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Domain.Entities;

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
            if (await _repository.IsExistCategory(command.Category, cancellationToken))
            {
                return OperationResult<bool>.FailureResult(" ", ApplicationMessages.DuplicatedRecord);
            }
            var categoryname = @EnumExtensions.ToDisplay(command.Category);
            CategoryEntity categoryEntity = new CategoryEntity(command.Category, categoryname);
            await _repository.AddAsync(categoryEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(cancellationToken, id);
            category.Delete();
            await _repository.UpdateAsync(category, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(cancellationToken, command.Id);
            var categoryname = @EnumExtensions.ToDisplay(command.Category);
            category.Edit(command.Category, categoryname);
            await _repository.UpdateAsync(category, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);


        }

        public async Task<List<CategoryEntity>> GetAllCategoryForFood(CancellationToken cancellationToken)
        {
         return   await _repository.GetAllCategoryForFood(cancellationToken);
        }

        public async Task<CategoryEntity> GetCategoryByCategoryType(CategoryType categoryType ,CancellationToken cancellationToken)
        {
          return  await _repository.GetCategoryByCategoryType(categoryType ,cancellationToken);
        }

        public async Task<EditCommand> GetDetails(Guid id, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(cancellationToken, id);
            EditCommand editCommand = new EditCommand()
            {
                Id = category.Id,
                Category = category.Category,
            };
            return editCommand;
        }
    }
}
