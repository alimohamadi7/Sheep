
namespace Sheep.Core.Application.Sheep.SheepFullPrice
{
    public class CreateCommand
    {
        public long? PriceSheep { get; set; }
        public long? Unabsorbedcosts { get; set; }
        public Guid SheepId { get; set; }
        public DateTime Calcuted { get; set; }
    }
}
