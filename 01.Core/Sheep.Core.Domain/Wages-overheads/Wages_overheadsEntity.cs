using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Wages_overheads
{
    public class Wages_overheadsEntity: BaseEntity<Guid>
    {
        public long Salary { get; set; }
        public long Overhead { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Wages_overheadsEntity() { }  
        public Wages_overheadsEntity(long salary, long overhead)
        {
            Salary = salary;
            Overhead = overhead;
            IsDeleted = false;

        }
        public void Edit( long salary, long overhead)
        {
            Salary = salary;
            Overhead = overhead;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
