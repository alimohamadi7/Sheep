using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepFullPriceEntity : BaseEntity<Guid>
    {
        public long? PriceSheep { get; set; }
        public long? Expectations { get; set; }
        public Guid SheepId { get; set; }
        public SheepEntity SheepEntity { get; set; }
        public SheepFullPriceEntity() { }
        public SheepFullPriceEntity(long? priceSheep, long? expectations, Guid sheepId)
        {
            PriceSheep = priceSheep;
            Expectations = expectations;
            SheepId = sheepId;
        }
        public void Update(long? priceSheep, long? expectations, Guid sheepId)
        {
            PriceSheep = priceSheep;
            Expectations = expectations;
            SheepId = sheepId;
        }
    }
}
