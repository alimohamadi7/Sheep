using Sheep.Framework.Domain.Entities;


namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CalcuteCommand
    {
        public Guid Id { get; set; }
        public string Food { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public GenderType Gender { get; set; }
        public CategoryType Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
