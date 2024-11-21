using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Sheep.Core.Application.Sheep.Contracts
{
    public class EditCommand
    {
        public Guid Id { get; set; }
        public Guid PastId { get; set; }
        public Guid? ParentId { get; set; }
        [Display(Name = "شماره دام")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = ValidationMessages.Number)]
        [MaxLength(15, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string SheepNumber { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? SheepbirthDate { get; set; }
        [Display(Name = "تاریخ خرید")]
        public string? SheepshopDate { get; set; }
        [Display(Name = "تاریخ فروش")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? SheepSellDate { get; set; }
        [Display(Name = "تاریخ تلف شدن")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? SheepwastedDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Display(Name = "وضعیت")]
        public State SheepState { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Display(Name = "جنسیت")]
        public GenderType Gender { get; set; }

    }
}
