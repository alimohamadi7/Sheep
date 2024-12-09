using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;

using System.ComponentModel.DataAnnotations;


namespace Sheep.Core.Application.Wages_overheads
{
    public class CreateCommand
    {
        [Display(Name = "دستمزد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        [RegularExpression(@"[1-9][0-9]*(,[0-9]*)*", ErrorMessage = ValidationMessages.Invalidnumber)]
        public string Salary { get; set; }
        [Display(Name = "سربار")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        [RegularExpression(@"[1-9][0-9]*(,[0-9]*)*", ErrorMessage = ValidationMessages.Invalidnumber)]
        public string Overhead { get; set; }
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Start { get; set; }
        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string End { get; set; }
    }
}
