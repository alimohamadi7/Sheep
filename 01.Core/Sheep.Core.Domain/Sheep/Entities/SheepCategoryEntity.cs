using Sheep.Core.Domain.Category;
using Sheep.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;


namespace Sheep.Core.Domain.Sheep.Entities
{
    public class SheepCategoryEntity : BaseEntity<Guid>
    {
        public Guid SheepId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryType ActiveCategory { get; set; }
        public GenderType Gender { get; set; }
        public DateTime Start_Zero_Three {  get; set; }
        public DateTime ? Zero_ThreeCalacute { get; set; }
        public DateTime End_Zero_Three { get; set; }
        public DateTime Start_Three_Six { get; set; }
        public DateTime Three_SixCalcute { get; set; }
        public DateTime End_Three_Six { get; set; }
        public DateTime Start_Six_Eighteen { get; set; }
        public DateTime Six_EighteenCalcute { get; set; }
        public DateTime End_Six_Eighteen { get; set; }
        public DateTime Start_Ram_Ewe { get; set; }
        public DateTime Ram_EweCalcute { get; set; }
        public bool IsDeleted { get; set; }
        public SheepEntity Sheep { get; set; }
        public CategoryEntity Category { get; set; }
        public SheepCategoryEntity() { }
        public SheepCategoryEntity(Guid sheepId, Guid categoryId, GenderType gender,CategoryType activecategory, DateTime start_Zero_Three,DateTime zero_ThreeCalcute, DateTime end_Zero_Three,
       DateTime start_Three_Six, DateTime Three_sixcalcute, DateTime end_Three_Six,DateTime start_Six_Eighteen, DateTime Six_eighteencalcute, DateTime end_Six_Eighteen,DateTime start_Ram_Ewe, DateTime ram_Ewecalcute)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start_Zero_Three = start_Zero_Three;
            Zero_ThreeCalacute = zero_ThreeCalcute;
            End_Zero_Three = end_Zero_Three;
            Start_Three_Six = start_Three_Six;
            Three_SixCalcute = Three_sixcalcute;
            End_Three_Six=end_Three_Six;
            Start_Six_Eighteen= start_Six_Eighteen;
            Six_EighteenCalcute = Six_eighteencalcute;
            End_Six_Eighteen =end_Six_Eighteen;
            Start_Ram_Ewe = start_Ram_Ewe;
            Ram_EweCalcute = ram_Ewecalcute;
            Gender = gender;
        }
        public void Edit(Guid sheepId, Guid categoryId, GenderType gender, CategoryType activecategory, DateTime start_Zero_Three, DateTime zero_ThreeCalcute, DateTime end_Zero_Three,
       DateTime start_Three_Six, DateTime Three_sixcalcute, DateTime end_Three_Six, DateTime start_Six_Eighteen, DateTime Six_eighteencalcute, DateTime end_Six_Eighteen, DateTime start_Ram_Ewe, DateTime ram_Ewecalcute)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start_Zero_Three = start_Zero_Three;
            Zero_ThreeCalacute = zero_ThreeCalcute;
            End_Zero_Three = end_Zero_Three;
            Start_Three_Six = start_Three_Six;
            Three_SixCalcute = Three_sixcalcute;
            End_Three_Six = end_Three_Six;
            Start_Six_Eighteen = start_Six_Eighteen;
            Six_EighteenCalcute = Six_eighteencalcute;
            End_Six_Eighteen = end_Six_Eighteen;
            Start_Ram_Ewe = start_Ram_Ewe;
            Ram_EweCalcute = ram_Ewecalcute;
            Gender = gender;
        }
        public void Delete() 
        {
            IsDeleted = true;
        }
    }
}
