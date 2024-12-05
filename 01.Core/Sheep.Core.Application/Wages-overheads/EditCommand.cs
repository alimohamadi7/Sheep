using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.Wages_overheads
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
