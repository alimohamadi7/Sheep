using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepFullPriceEntity : BaseEntity<Guid>
    {
        public double? PriceSheep { get; set; }
        public double? Unabsorbedcosts { get; set; }
        public Guid SheepId { get; set; }
        public DateTime Calcuted { get; set; }
        public SheepEntity SheepEntity { get; set; }
        public SheepFullPriceEntity() { }
        public SheepFullPriceEntity(double? priceSheep, double? unabsorbedcosts, Guid sheepId, DateTime calcuted)
        {
            PriceSheep = priceSheep;
            Unabsorbedcosts = unabsorbedcosts;
            SheepId = sheepId;
            Calcuted=calcuted;
        }
        public void Edit(double? priceSheep, double? unabsorbedcosts, Guid sheepId,DateTime calcuted)
        {
            PriceSheep = priceSheep;
            Unabsorbedcosts = unabsorbedcosts;
            SheepId = sheepId;
            Calcuted=calcuted;
        }
    }
}
