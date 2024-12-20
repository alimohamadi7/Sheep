﻿

using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Sheep.PricePeriod
{
    public class CreateCommand
    {
        public Guid SheepNumber { get; set; }
        public double? PriceSheep { get; set; }
        public double? Unabsorbedcosts { get; set; }
        public double PricePerSheep { get; set; }
       public Guid CategoryPriceId { get; set; }
       public GenderType Gender { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Calcuted { get; set; }
    }
}
