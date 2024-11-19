using Sheep.Framework.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category
{
    public class EditCommand
    {
        public Guid Id { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Name { get; set; }

    }
}
