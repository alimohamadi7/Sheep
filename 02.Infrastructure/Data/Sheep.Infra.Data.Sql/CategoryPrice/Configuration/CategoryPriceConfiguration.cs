

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Category;
using Sheep.Core.Domain.Sheep.Entities;

namespace Sheep.Infra.Data.Sql.CategoryPrice.Configuration
{
    public class CategoryPriceConfiguration : IEntityTypeConfiguration<CategoryPriceEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryPriceEntity> builder)
        {
            builder.ToTable(nameof(CategoryPriceEntity));
            builder.HasKey(e => e.Id);
            builder.HasMany(x => x.SheepPricePeriods).WithOne(x => x.CategoryPriceEntity).
            HasForeignKey(x => x.CategoryPriceId);
        }
    }
}
