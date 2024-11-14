

using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category
{
    public class CreateCommand
    {
        [Display(Name = "نام گروه")]
        [Required (ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Name { get; set; }


    }
}
