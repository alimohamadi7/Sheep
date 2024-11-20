using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Framework.Domain.Entities
{
    public enum State
    {
        [Display(Name = "انتخاب کنید ")]
        None=0,
        [Display(Name = "موجود")]
        present = 1,
        [Display(Name = "فروخته شده")]
        Sall = 2,
        [Display(Name = "تلف شده ")]
        wasted = 3,

    }

}
