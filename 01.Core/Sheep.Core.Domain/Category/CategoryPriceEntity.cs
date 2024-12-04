using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Category
{
    public class CategoryPriceEntity : BaseEntity<Guid>
    {
        public bool IsDeleted { get; set; }
        public long Food { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public CategoryPriceEntity() { }
        public CategoryPriceEntity(long food)
        {
            Food = food;
            IsDeleted = false;

        }
        public void Edit(long food)
        {
            Food = food;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
