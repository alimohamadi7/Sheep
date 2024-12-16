using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepPricePeriodEntity:BaseEntity<Guid>
    {
        public Guid SheepId { get; set; }
        public Guid CategoryPriceId { get; set; }
        public long? PriceSheep { get; set; }
        public long? Unabsorbedcosts { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public SheepEntity SheepEntity { get; set; }
        public CategoryPriceEntity CategoryPriceEntity { get; set; }
        public SheepPricePeriodEntity() { }
        public SheepPricePeriodEntity(Guid sheepId, Guid categoryPriceId, long? pricesheep,long? unabsorbedcosts ,DateTime start,DateTime end)
        {
            PriceSheep = pricesheep;
            Unabsorbedcosts = unabsorbedcosts;
            Start = start;
            End = end;
            SheepId=sheepId;
            CategoryPriceId=categoryPriceId;
        }
        public void Edit(Guid sheepId, Guid categoryPriceId, long? pricesheep, long? unabsorbedcosts, DateTime start, DateTime end)
        {
            PriceSheep = pricesheep;
            Unabsorbedcosts = unabsorbedcosts;
            Start = start;
            End = end;
            SheepId = sheepId;
            CategoryPriceId = categoryPriceId;
        }
    }
}
