using Microsoft.Data.SqlClient;
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
            builder.HasOne(x => x.Sheep).WithMany(x => x.SheepGroup).
                HasForeignKey(x => x.SheepId);
            builder.HasOne(x => x.Category).WithMany(x => x.SheepGroups).
                HasForeignKey(x => x.CategoryId);
        }
    }
}
