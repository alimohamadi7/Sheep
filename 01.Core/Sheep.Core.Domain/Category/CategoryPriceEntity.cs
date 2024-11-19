using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Category
{
    public class CategoryPriceEntity : BaseEntity<Guid>
    {
        public bool IsDeleted { get; set; }
        public long Food { get; set; }
        public long Salary { get; set; }
        public long Overhead { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public CategoryPriceEntity() { }
        public CategoryPriceEntity(long food, long salary, long overhead)
        {
            Food = food;
            Salary = salary;
            Overhead = overhead;
            IsDeleted = false;

        }
        public void Edit(long food, long salary, long overhead)
        {
            Food = food;
            Salary = salary;
            Overhead = overhead;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
