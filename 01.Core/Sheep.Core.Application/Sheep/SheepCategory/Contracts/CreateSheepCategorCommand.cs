
using Sheep.Framework.Domain.Entities;

namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public class CreateSheepCategorCommand
    {
        public Guid CategoryId { get; set; }
        public Guid SheepId { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age {  get; set; }
        public GenderType Gender { get; set; } 
        public bool ActiveCategory {  get; set; }
    }
}
