using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Fiscalyear
{
    public class FiscalyearEntity:BaseEntity<Guid>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive {  get; set; } 
        public FiscalyearEntity() { }
        public FiscalyearEntity(DateTime start , DateTime end) 
        { 
            Start = start;
            End = end;
            IsActive = true;
            IsDeleted = false;
        }
        public void Edit(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            IsActive= true;
        }
        public void Delete() 
        {
            IsDeleted = false;
            IsActive=false;
        }

    }
}
