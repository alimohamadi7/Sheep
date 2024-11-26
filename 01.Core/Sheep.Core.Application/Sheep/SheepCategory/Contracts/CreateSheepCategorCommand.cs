
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public class CreateSheepCategorCommand
    {
        public Guid CategoryId { get; set; }
        public Guid SheepId { get; set; }
        public CategoryType ActiveCategory { get; set; }
        public DateTime Start_Zero_Three { get; set; }
        public DateTime End_Zero_Three { get; set; }
        public DateTime End_Three_Six { get; set; }
        public DateTime End_Six_Eighteen { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age {  get; set; }
        public GenderType Gender { get; set; } 
    }
}
