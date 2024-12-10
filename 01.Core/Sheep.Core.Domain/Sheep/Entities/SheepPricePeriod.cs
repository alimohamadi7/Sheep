using Sheep.Framework.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepPricePeriod:BaseEntity<Guid>
    {
        public long? PriceSheep { get; set; }
        public long? Unabsorbedcosts { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public SheepPricePeriod() { }
        public SheepPricePeriod(long pricesheep,long unabsorbedcosts ,DateTime start,DateTime end)
        {
            PriceSheep = pricesheep;
            Unabsorbedcosts = unabsorbedcosts;
            Start = start;
            End = end;
        }
        public void Edit(long pricesheep, long unabsorbedcosts, DateTime start, DateTime end)
        {
            PriceSheep = pricesheep;
            Unabsorbedcosts = unabsorbedcosts;
            Start = start;
            End = end;
        }
    }
}
