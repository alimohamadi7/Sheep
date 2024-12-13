

namespace Sheep.Core.Application.Sheep.SheepCategory.Contracts
{
    public class EditSheepCategoryCommand: CreateSheepCategoryCommand
    {
        public Guid Id { get; set; }
    }
}
