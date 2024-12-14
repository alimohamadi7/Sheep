using Sheep.Framework.Domain.Entities;
using System.Reflection;

namespace Sheep.Core.Domain.Category
{
    public class CategoryPriceEntity : BaseEntity<Guid>
    {
        public bool IsDeleted { get; set; }
        public long Food { get; set; }
        public GenderType Gender { get; set; }
        public CategoryType Category { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public Guid CategoryId { get; set; }
        public double PricePerSheep { get; set; } 
        public bool Calculated { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public CategoryPriceEntity() { }
        public CategoryPriceEntity(long food,GenderType gender , CategoryType category, DateTime start,DateTime end ,Guid categoryid)
        {
            Food = food;
            IsDeleted = false;
            Gender = gender;
            Start = start;
            End = end;
            CategoryId = categoryid;
            Category=category;
            Calculated = false;
        }
        public void Edit(long food,GenderType gender, CategoryType category, DateTime start,DateTime end ,Guid categoryid)
        {
            Food = food;
            Gender = gender;
            Start = start;
            End = end;
            CategoryId = categoryid;
            Category= category;

        }
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
