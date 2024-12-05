using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Category
{
    public class CategoryEntity : BaseEntity<Guid>
    {
        public CategoryType Category { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SheepCategoryEntity> sheepCategoryEntities { get; set; }
        public ICollection<CategoryPriceEntity> CategoryEntities { get; set; }
        public CategoryEntity() { }
        public CategoryEntity(CategoryType category, string categoryname)
        {
            Category = category;
            CategoryName = categoryname;

            IsDeleted = false;
        }
        public void Edit(CategoryType category,string categoryname)
        {
            Category = category;
            CategoryName = categoryname;

        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
