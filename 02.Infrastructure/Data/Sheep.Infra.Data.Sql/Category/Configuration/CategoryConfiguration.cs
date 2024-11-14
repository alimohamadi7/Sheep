using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Infra.Data.Sql.Category.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable(nameof(CategoryEntity));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.SheepGroups).WithOne(x => x.Category).
                HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.CategoryEntities).WithOne(x=>x.CategoryEntity).
                HasForeignKey(x => x.CategoryId);   
        }
    }
}
