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
        public string Name { get; set; }
        [Display(Name = "جنسیت")]
        public GenderType Gender { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "خوراک مصرفی")]
        public long Food { get; set; }
        [Display(Name = "دستمزد")]
        public long Salary { get; set; }
        [Display(Name = "سربار")]
        public long Overhead { get; set; }
    }
}
