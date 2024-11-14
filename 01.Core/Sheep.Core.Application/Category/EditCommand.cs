using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
