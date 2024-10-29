
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Sheep.Entities;

namespace Sheep.Infra.Data.Sql.Sheep.Configuration
{
    public class SheepConfiguration : IEntityTypeConfiguration<SheepEntity>
    {
        public void Configure(EntityTypeBuilder<SheepEntity> builder)
        {
            builder.ToTable(nameof(SheepEntity));
            builder.HasKey(e => e.Id);
            builder.Property(x => x.SheepNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.SheepbirthDate).IsRequired();
            //builder.Property(x => x.Sheepshop).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.HasMany(x => x.SheepEntites).WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SheepGroup).WithOne(x => x.Sheep).
                HasForeignKey(x => x.SheepId);
            builder.HasMany(x => x.SheepFullPrices).WithOne(x => x.SheepEntity).
                HasForeignKey(x => x.SheepId);
        }
    }
}
