

using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Sheep.PricePeriod
{
    public class CreateCommand
    {
        public Guid SheepNumber { get; set; }
        public long? PriceSheep { get; set; }
        public long? Unabsorbedcosts { get; set; }
       public GenderType Gender { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
