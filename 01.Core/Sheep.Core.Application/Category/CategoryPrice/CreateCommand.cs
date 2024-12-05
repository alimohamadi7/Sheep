﻿using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Core.Application.Category.CategoryPrice
{
    public class CreateCommand
    {
        [Display(Name = "خوراک")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [NotZero(ErrorMessage = ValidationMessages.NotZero)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = ValidationMessages.Invalidnumber)]
        public long Food { get; set; }
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Start { get; set; }
        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string End { get; set; }
        public Guid CategoryId { get; set; }
    }
}
