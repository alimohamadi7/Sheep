using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CreateCommand
    {
        [Display(Name = "دستمزد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        public long Salary { get; set; }
        [Display(Name = "سربار")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        public long Overhead { get; set; }
    }
}
