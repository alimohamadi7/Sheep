using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CreateCommand
    {
        [Display(Name = "خوراک")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        //[NotZero(ErrorMessage = ValidationMessages.NotZero)]
        [RegularExpression(@"[1-9][0-9]*(,[0-9]*)*", ErrorMessage = ValidationMessages.Invalidnumber)]
        public string Food { get; set; }
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Start { get; set; }
        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string End { get; set; }
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public GenderType Gender { get; set; }
        [Display(Name = "گروه")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        public CategoryType Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
