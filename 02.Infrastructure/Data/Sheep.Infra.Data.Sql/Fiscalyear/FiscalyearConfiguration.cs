using Microsoft.EntityFrameworkCore;
using Sheep.Core.Domain.Fiscalyear;
using Sheep.Core.Domain.Wages_overheads;

namespace Sheep.Infra.Data.Sql.Fiscalyear

{
    internal class FiscalyearConfiguration : IEntityTypeConfiguration<FiscalyearEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FiscalyearEntity> builder)
        {
            builder.ToTable(nameof(FiscalyearEntity));
            builder.HasKey(x => x.Id);
        }
    }
}
