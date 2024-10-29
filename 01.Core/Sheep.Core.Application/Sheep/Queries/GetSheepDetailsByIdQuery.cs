using MediatR;
using Sheep.Core.Application.Sheep.Command;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Application.Validation;
using Sheep.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Core.Application.Sheep.Queries
{
    public class GetSheepDetailsByIdQuery:IRequest<OperationResult<EditCommand>>
    {
        public Guid Id { get; set; }    
        [Display(Name = "شماره دام")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = ValidationMessages.Number)]
        [MaxLength(15, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string SheepNumber { get; set; }
        [Display(Name = "شماره دام مادر")]
        public Guid? ParentId { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public DateTime SheepbirthDate { get; set; }
        [Display(Name = "تاریخ خرید")]
        public DateTime? Sheepshop { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Display(Name = "وضعیت")]
        public State SheepState { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Display(Name = "جنسیت")]
        public GenderType Gender { get; set; }
    }
}
