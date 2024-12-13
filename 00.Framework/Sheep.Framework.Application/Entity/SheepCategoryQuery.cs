
using Sheep.Framework.Domain.Entities;

namespace Sheep.Framework.Application.Entity
{
    public class SheepCategoryQuery
    {
        public GenderType GenderType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
