
using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Category.CategoryPrice.Contracts
{
    public class CalcuteCommand
    {
        public string Food { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public GenderType Gender { get; set; }
        public CategoryType Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
