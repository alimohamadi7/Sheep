using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Category
{
    public class CategoryEntity : BaseEntity<Guid>
    {
        public CategoryType Category { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SheepCategoryEntity> SheepGroups { get; set; }
        public ICollection<CategoryPriceEntity> CategoryEntities { get; set; }
        public CategoryEntity() { }
        public CategoryEntity(CategoryType category)
        {
            Category = category;

            IsDeleted = false;
        }
        public void Edit(CategoryType category)
        {
            Category = category;

        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
