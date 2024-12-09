
using Sheep.Framework.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Fiscalyear
{
    public class CreateCommand
    {
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Start { get; set; }
        [Display(Name = "تاریخ پایان")]
    }
}
