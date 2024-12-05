using Sheep.Core.Application.Category.CategoryPrice.Contracts;


namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CategoryPriceApplication : ICategoryPriceApplication
    {
        private readonly ICategoryPriceRepository _categoryPriceRepository;

        public CategoryPriceApplication(ICategoryPriceRepository categoryPriceRepository)
        {
            _categoryPriceRepository = categoryPriceRepository;
        }

        public async Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            return await _categoryPriceRepository.GetAll(cancellationToken, PageId, trim);
        }
    }
}
