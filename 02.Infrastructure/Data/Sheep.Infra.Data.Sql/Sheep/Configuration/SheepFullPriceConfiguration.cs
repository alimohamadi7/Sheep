using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Sheep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Infra.Data.Sql.Sheep.Configuration
{
    public class SheepFullPriceConfiguration : IEntityTypeConfiguration<SheepFullPriceEntity>
    {
        public void Configure(EntityTypeBuilder<SheepFullPriceEntity> builder)
        {
            builder.ToTable(nameof(SheepFullPriceEntity));
            builder.HasKey(e => e.Id);
            builder.Property(x => x.PriceSheep).IsRequired(false);
            builder.Property(x => x.Expectations).IsRequired(false);
            builder.HasOne(x => x.SheepEntity).WithMany(x => x.SheepFullPrices).
                HasForeignKey(x => x.SheepId);
        }
    }
}
