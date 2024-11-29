using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Sheep.Entities;

namespace Sheep.Infra.Data.Sql.Sheep.Configuration
{
    public class SheepCategoryConfiguration : IEntityTypeConfiguration<SheepCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<SheepCategoryEntity> builder)
        {
            builder.ToTable(nameof(SheepCategoryEntity));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Start_Zero_Three).HasColumnOrder(6);
            builder.HasOne(x => x.Sheep).WithMany(x => x.SheepCategories).
                HasForeignKey(x => x.SheepId);
            builder.HasOne(x => x.Category).WithMany(x => x.sheepCategoryEntities).
                HasForeignKey(x => x.CategoryId);
        }
    }
}
