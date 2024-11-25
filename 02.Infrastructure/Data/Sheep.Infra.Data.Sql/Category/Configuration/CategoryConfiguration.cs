using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Category;

namespace Sheep.Infra.Data.Sql.Category.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable(nameof(CategoryEntity));
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.sheepCategoryEntities).WithOne(x => x.Category).
                HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.CategoryEntities).WithOne(x => x.CategoryEntity).
                HasForeignKey(x => x.CategoryId);
        }
    }
}
