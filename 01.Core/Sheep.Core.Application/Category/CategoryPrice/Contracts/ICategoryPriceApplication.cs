



namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public interface ICategoryPriceApplication
    {
        Task<GetCategoryPriceQuery> GetAll(CancellationToken cancellationToken, int PageId = 1, string trim = "");
    }
}
