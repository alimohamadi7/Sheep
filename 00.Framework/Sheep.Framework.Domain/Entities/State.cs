using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sheep.Framework.Domain.Entities
{
    public enum State
    {
        [Display(Name = "موجود")]
        present = 1,
        [Display(Name = "فروخته شده")]
        Sell = 2,
        [Display(Name = "تلف شده ")]
        wasted = 3,

    }

}
