

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class EditCommand:CreateCommand
    {
        public Guid Id { get; set; }
        public DateTime StartLaste { get; set; }
        public DateTime EndLaste { get; set; }
    }
}
