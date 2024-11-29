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
        public bool IsDeleted { get; set; }
        public DateTime Start_Zero_Three {  get; set; }
        public DateTime End_Zero_Three { get; set; }
        public DateTime End_Three_Six { get; set; }
        public DateTime End_Six_Eighteen { get; set; }
        public SheepEntity Sheep { get; set; }
        public CategoryEntity Category { get; set; }
        public SheepCategoryEntity() { }
        public SheepCategoryEntity(Guid sheepId, Guid categoryId, CategoryType activecategory, DateTime start_Zero_Three, DateTime end_Zero_Three,
            DateTime end_Three_Six,DateTime end_Six_Eighteen)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start_Zero_Three = start_Zero_Three;
            End_Zero_Three = end_Zero_Three;
            End_Three_Six=end_Three_Six;
            End_Six_Eighteen=end_Six_Eighteen;
        }
        public void Edit(Guid sheepId, Guid categoryId, CategoryType activecategory, DateTime start_Zero_Three, DateTime end_Zero_Three,
            DateTime end_Three_Six, DateTime end_Six_Eighteen)
        {
            SheepId = sheepId;
            CategoryId = categoryId;
            ActiveCategory = activecategory;
            Start_Zero_Three = start_Zero_Three;
            End_Zero_Three = end_Zero_Three;
            End_Three_Six = end_Three_Six;
            End_Six_Eighteen = end_Six_Eighteen;
        }
    }
}
