using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepCategoryEntity : BaseEntity<Guid>
    {
        public Guid SheepId { get; set; }
        public Guid GroupId { get; set; }
        public SheepEntity Sheep { get; set; }
        public CategoryEntity Group { get; set; }
        public bool ActiveGroup { get; set; }
        public SheepCategoryEntity() { }
        public SheepCategoryEntity(Guid sheepId, Guid groupId, bool activeGroup)
        {
            SheepId = sheepId;
            GroupId = groupId;
            ActiveGroup = activeGroup;
        }
        public void Update(Guid sheepId, Guid groupId, bool activeGroup)
        {
            SheepId = sheepId;
            GroupId = groupId;
            ActiveGroup = activeGroup;
        }
    }
}
