

using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category
{
    public class CreateCommand
    {
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public CategoryType Category { get; set; }


    }
}
