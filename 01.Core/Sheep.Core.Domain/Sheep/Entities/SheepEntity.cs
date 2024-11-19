using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepEntity : BaseEntity<Guid>
    {
        public string SheepNumber { get; set; }
        public DateTime? SheepbirthDate { get; set; }
        public DateTime? Sheepshop { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public State SheepState { get; set; }
        public GenderType Gender { get; set; }
        public SheepEntity Parent { get; set; }
        public ICollection<SheepEntity> SheepEntites { get; set; }
        public ICollection<SheepCategoryEntity> SheepGroup { get; set; }
        public ICollection<SheepFullPriceEntity> SheepFullPrices { get; set; }
        public SheepEntity() { }
        public SheepEntity(string sheepNumber, DateTime? sheepbirthDate, DateTime? sheepshop, Guid? parentId, State sheepState, GenderType gender)
        {
            SheepNumber = sheepNumber;
            SheepbirthDate = sheepbirthDate;
            Sheepshop = sheepshop;
            ParentId = parentId;
            IsDeleted = false;
            SheepState = sheepState;
            Gender = gender;
        }
        public void Edit(string sheepNumber, DateTime? sheepbirthDate, DateTime? sheepshop, Guid? parentId, State sheepState, GenderType gender)
        {
            SheepNumber = sheepNumber;
            SheepbirthDate = sheepbirthDate;
            Sheepshop = sheepshop;
            ParentId = parentId;
            SheepState = sheepState;
            Gender = gender;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
