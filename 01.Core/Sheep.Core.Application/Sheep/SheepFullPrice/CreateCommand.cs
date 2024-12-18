
namespace Sheep.Core.Application.Sheep.SheepFullPrice
{
    public class CreateCommand
    {
        public double? PriceSheep { get; set; }
        public double? Unabsorbedcosts { get; set; }
        public Guid SheepId { get; set; }
        public DateTime Calcuted { get; set; }
    }
}
