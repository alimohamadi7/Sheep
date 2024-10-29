using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Sheep.Entities;

namespace Sheep.Infra.Data.Sql.Sheep.Configuration
{
    public class SheepGroupConfiguration : IEntityTypeConfiguration<SheepGroupEntity>
    {
        public void Configure(EntityTypeBuilder<SheepGroupEntity> builder)
        {
            builder.ToTable(nameof(SheepGroupEntity));
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Sheep).WithMany(x => x.SheepGroup).
                HasForeignKey(x => x.SheepId);
            builder.HasOne(x => x.Group).WithMany(x => x.SheepGroups).
                HasForeignKey(x => x.GroupId);
        }
    }
}
