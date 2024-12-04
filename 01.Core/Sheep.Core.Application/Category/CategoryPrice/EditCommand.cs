using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class EditCommand
    {
        public Guid Id { get; set; }
        [Display(Name = "دستمزد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public long Salary { get; set; }
        [Display(Name = "سربار")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public long Overhead { get; set; }
    }
}
