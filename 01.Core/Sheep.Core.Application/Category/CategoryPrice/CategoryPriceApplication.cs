using Sheep.Core.Application.Category.CategoryPrice.Contracts;


namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CategoryPriceApplication : ICategoryPriceApplication
    {
        public Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "")
        {
            throw new NotImplementedException();
        }
    }
}
