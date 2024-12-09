using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepFullPriceEntity : BaseEntity<Guid>
    {
        public long? PriceSheep { get; set; }
        public long? Unabsorbedcosts { get; set; }
        public Guid SheepId { get; set; }
        public SheepEntity SheepEntity { get; set; }
        public SheepFullPriceEntity() { }
        public SheepFullPriceEntity(long? priceSheep, long? unabsorbedcosts, Guid sheepId)
        {
            PriceSheep = priceSheep;
            Unabsorbedcosts = unabsorbedcosts;
            SheepId = sheepId;
        }
        public void Edit(long? priceSheep, long? unabsorbedcosts, Guid sheepId)
        {
            PriceSheep = priceSheep;
            Unabsorbedcosts = unabsorbedcosts;
            SheepId = sheepId;
        }
    }
}
