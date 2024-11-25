using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category
{
    public class EditCommand
    {
        public Guid Id { get; set; }
        [Display(Name = "نام گروه")]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public CategoryType Category { get; set; }

    }
}
