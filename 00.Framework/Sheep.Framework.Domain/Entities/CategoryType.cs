
using System.ComponentModel.DataAnnotations;


namespace Sheep.Framework.Domain.Entities
{
    public enum CategoryType
    {
        [Display(Name = "انتخاب کنید")]
        none = 0,
        [Display(Name = "صفر تا سه ماه ")]
        Zero_Three = 90,
        [Display(Name = "سه تا شش ماه ")]
        Three_Six = 180,
        [Display(Name = "شش تا هجده ماه")]
        Six_Eighteen = 540,
        [Display(Name = "میش")]
        Ewe = 1,
        [Display(Name = "قوچ")]
        Ram = 2,
    }
}
