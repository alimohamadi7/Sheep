using System.ComponentModel.DataAnnotations;

namespace Sheep.Framework.Domain.Entities
{

    public enum State
    {
        [Display(Name = "فروخته شده")]
        Sall = 0,
        [Display(Name = "تلف شده ")]
        wasted = 1,
        [Display(Name = "موجود")]
        present = 2
    }

}
