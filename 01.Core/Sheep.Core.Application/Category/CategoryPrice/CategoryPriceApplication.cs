using DNTPersianUtils.Core;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Application.Operation;
using System.Globalization;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CategoryPriceApplication : ICategoryPriceApplication
    {
        private readonly ICategoryPriceRepository _categoryPriceRepository;

        public CategoryPriceApplication(ICategoryPriceRepository categoryPriceRepository)
        {
            _categoryPriceRepository = categoryPriceRepository;
        }

        public async Task<OperationResult<bool>> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            var on = command.Food.Replace(',', ' ').RemoveAllWhitespaces();
            var ON2 = command.Food..Trim(new Char[] { ' ', '*', '.' });
            var Food =Convert.ToInt64(on);
            CategoryPriceEntity categoryPriceEntity = new CategoryPriceEntity(Food,command.Gender,Convert.ToDateTime( command.Start.ToPersianDateTime()) ,
              Convert.ToDateTime(command.End.ToPersianDateTime()),command.CategoryId);
          await _categoryPriceRepository.AddAsync(categoryPriceEntity, cancellationToken);
            return OperationResult<bool>.SuccessResult(true);

        }

        public async Task<OperationResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceRepository.GetByIdAsync(cancellationToken, id);
            result.Delete();
         await   _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true) ; 
        }

        public async Task<OperationResult<bool>> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            var Food = Convert.ToInt64(command.Food.Remove(','));
            var result =await _categoryPriceRepository.GetByIdAsync(cancellationToken, command.Id);
            result.Edit(Food, command.Gender, Convert.ToDateTime(command.Start.ToPersianDateTime()),
              Convert.ToDateTime(command.End.ToPersianDateTime()), command.CategoryId);
         await   _categoryPriceRepository.SaveChangesAsync(cancellationToken);
            return OperationResult<bool>.SuccessResult(true);
        }

        public async Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            return await _categoryPriceRepository.GetAll(cancellationToken, PageId, trim);
        }


    }
}
