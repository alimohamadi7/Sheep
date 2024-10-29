using System.ComponentModel.DataAnnotations;


namespace Sheep.Framework.Domain.Entities
{
    public enum GenderType
    {
        [Display(Name = "نر")]
        Male = 1,

        [Display(Name = "ماده")]
        Female = 2
    }
}
