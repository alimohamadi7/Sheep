using Framework.Application.Entity;
using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;



namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class GetCategoryPriceQuery : BasePagging
    {
        public List<CategoryPriceEntity> CategoryPriceEntities { get; set; }
        public string? Start { get; set; }
        public string ?End {  get; set; }
        public CategoryType Category {  get; set; }
        public GenderType Gender { get; set; }
    }
}
