using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Framework.Domain.Entities
{

     public enum State
        {
        [Display(Name = "فروخته شده")]
        Sall =0,
        [Display(Name = "تلف شده ")]
        wasted=1,
        [Display(Name = "موجود")]
        present=2
        }

}
