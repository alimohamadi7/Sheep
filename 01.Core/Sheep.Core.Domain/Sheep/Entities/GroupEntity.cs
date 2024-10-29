using Sheep.Framework.Domain.Entities;
using System.Diagnostics.Contracts;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class GroupEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public bool IsDeleted { get; set; }
        public long Food { get; set; }
        public long Salary { get; set; }
        public long Overhead { get; set; }
        public ICollection<SheepGroupEntity> SheepGroups { get; set; }
        public GroupEntity() { }
        public GroupEntity(string name, int gender, bool isDeleted, long food, long salary, long overhead)
        {
            Name = name;
            Gender = gender;
            IsDeleted = isDeleted;
            Food = food;
            Salary = salary;
            Overhead = overhead;
            isDeleted = false;
        }
        public void Update(string name, int gender, bool isDeleted, long food, long salary, long overhead)
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
