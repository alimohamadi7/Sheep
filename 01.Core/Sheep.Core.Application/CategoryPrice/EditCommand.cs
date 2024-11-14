using Sheep.Framework.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.CategoryPrice
{
     public class EditCommand
    {
        public Guid Id { get; set; }    
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        [Display(Name = "خوراک مصرفی")]
        public long Food { get; set; }
        [Display(Name = "دستمزد")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long Salary { get; set; }
        [Display(Name = "سربار")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long Overhead { get; set; }
    }
}
