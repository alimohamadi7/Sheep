using Sheep.Core.Domain.Sheep.Entities;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Category
{
    public class CategoryEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SheepCategoryEntity> SheepGroups { get; set; }
        public ICollection<CategoryPriceEntity> CategoryEntities { get; set; }
        public CategoryEntity() { }
        public CategoryEntity(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;

            IsDeleted = false;
        }
        public void Edit(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;

        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
