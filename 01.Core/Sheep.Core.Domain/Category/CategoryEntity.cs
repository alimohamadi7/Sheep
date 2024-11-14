using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Category
{
    public class CategoryEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SheepCategoryEntity> SheepGroups { get; set; }
        public ICollection<CategoryPriceEntity> CategoryEntities { get; set; }
        public CategoryEntity() { }
        public CategoryEntity(string name)
        {
            Name = name;

            IsDeleted = false;
        }
        public void Edit(string name)
        {
            Name = name;

        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
