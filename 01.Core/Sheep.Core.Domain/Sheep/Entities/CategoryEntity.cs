using Sheep.Framework.Domain.Entities;
using System.Diagnostics.Contracts;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class CategoryEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public bool IsDeleted { get; set; }
        public long Food { get; set; }
        public long Salary { get; set; }
        public long Overhead { get; set; }
        public ICollection<SheepCategoryEntity> SheepGroups { get; set; }
        public CategoryEntity() { }
        public CategoryEntity(string name, GenderType gender, bool isDeleted, long food, long salary, long overhead)
        {
            Name = name;
            Gender = gender;
            IsDeleted = isDeleted;
            Food = food;
            Salary = salary;
            Overhead = overhead;
          IsDeleted = false;
        }
        public void Update(string name, GenderType gender, bool isDeleted, long food, long salary, long overhead)
        {
            Name = name;
            Gender = gender;
            IsDeleted = isDeleted;
            Food = food;
            Salary = salary;
            Overhead = overhead;
        }
        public void Delete(bool isdeleted)
        {
            IsDeleted = isdeleted;
        }
    }
}
