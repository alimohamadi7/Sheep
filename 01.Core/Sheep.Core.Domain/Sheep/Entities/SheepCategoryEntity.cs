using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepCategoryEntity : BaseEntity<Guid>
    {
        public Guid SheepId { get; set; }
        public Guid CategoryId { get; set; }
        public bool ActiveCategory { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public SheepEntity Sheep { get; set; }
        public CategoryEntity Category { get; set; }
        public SheepCategoryEntity() { }
        public SheepCategoryEntity(Guid sheepId, Guid categoryId, bool activecategory, DateTime start, DateTime end)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start = start;
            End = end;  
        }
        public void Edit(Guid sheepId, Guid categoryId, bool activecategory, DateTime start, DateTime end)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start = start;
            End = end;
        }
    }
}
