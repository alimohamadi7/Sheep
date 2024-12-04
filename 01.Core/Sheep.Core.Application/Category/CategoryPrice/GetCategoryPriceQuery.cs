using Framework.Application.Entity;
using Sheep.Core.Domain.Category;


namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class GetCategoryPriceQuery : BasePagging
    {
        public List<CategoryPriceEntity> CategoryPriceEntities { get; set; }
        public string trim { get; set; }
    }
}
