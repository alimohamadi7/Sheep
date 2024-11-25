﻿using Sheep.Core.Application.Category.Contracts;
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
            if (!await _repository.IsExistCategory(command.Category.HasFlag, cancellationToken))
            {
                return OperationResult<bool>.FailureResult(" ", ApplicationMessages.DuplicatedRecord);
            }
            CategoryEntity categoryEntity = new CategoryEntity(command.Category)
        ;
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
            category.Edit(command.Category);
            await _repository.UpdateAsync(category, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<OperationResult<GetCategoryQouery>> GetAllCategory(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);


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
