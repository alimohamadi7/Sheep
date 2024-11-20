using System.ComponentModel.DataAnnotations;


namespace Sheep.Framework.Domain.Entities
{
    public enum GenderType
    {
        [Display(Name = "انتخاب کنید")]
        None =0, 
        [Display(Name = "نر")]
        Male = 1,

        [Display(Name = "ماده")]
        Female = 2
    }
}
