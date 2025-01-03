﻿using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepEntity : BaseEntity<Guid>
    {
        public string SheepNumber { get; set; }
        public DateTime SheepbirthDate { get; set; }
        public DateTime? SheepshopDate { get; set; }
        public DateTime? SheepSellDate { get; set; }
        public DateTime? SheepwastedDate { get; set; }
        public Guid? ParentId { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public State SheepState { get; set; }
        public GenderType Gender { get; set; }
        public SheepEntity Parent { get; set; }
        public ICollection<SheepEntity> SheepEntites { get; set; }
        public ICollection<SheepCategoryEntity> SheepCategories { get; set; }
        public ICollection<SheepFullPriceEntity> SheepFullPrices { get; set; }
        public ICollection<SheepPricePeriodEntity>SheepPricePeriods { get; set; }
        public SheepEntity() { }
        public SheepEntity(string sheepNumber, DateTime sheepbirthDate, DateTime? sheepshop, 
            Guid? parentId, State sheepState, GenderType gender,int age)
        {
            
            SheepNumber = sheepNumber;
            SheepbirthDate = sheepbirthDate;
            SheepshopDate = sheepshop;
            ParentId = parentId;
            IsDeleted = false;
            SheepState = sheepState;
            Gender = gender;
            SheepSellDate = null;
            SheepwastedDate= null;
            Age = age;
            SheepState = State.present;
        }
        public void Edit(string sheepNumber, DateTime sheepbirthDate, DateTime? sheepshop, Guid? parentId, State sheepState, GenderType gender, int age)
        {
         
            SheepNumber = sheepNumber;
            SheepbirthDate = sheepbirthDate;
            SheepshopDate = sheepshop;
            ParentId = parentId;
            SheepState = sheepState;
            Gender = gender;
            SheepSellDate = null;
            SheepwastedDate = null;
            Age= age;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
