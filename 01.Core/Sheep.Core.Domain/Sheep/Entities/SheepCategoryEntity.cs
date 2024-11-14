using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepCategoryEntity : BaseEntity<Guid>
    {
        public Guid SheepId { get; set; }
        public Guid CategoryId { get; set; }
        public SheepEntity Sheep { get; set; }
        public CategoryEntity Category { get; set; }
        public bool ActiveGroup { get; set; }
        public SheepCategoryEntity() { }
        public SheepCategoryEntity(Guid sheepId, Guid categoryId, bool activeGroup)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveGroup = activeGroup;
        }
        public void Update(Guid sheepId, Guid categoryId, bool activeGroup)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveGroup = activeGroup;
        }
    }
}
