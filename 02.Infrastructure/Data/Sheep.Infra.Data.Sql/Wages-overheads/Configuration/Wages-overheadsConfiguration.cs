using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheep.Core.Domain.Category;
using Sheep.Core.Domain.Wages_overheads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Infra.Data.Sql.Wages_overheads
{
    public class Wages_overheadsConfiguration : IEntityTypeConfiguration<Wages_overheadsEntity>
    {
        public void Configure(EntityTypeBuilder<Wages_overheadsEntity> builder)
        {
            builder.ToTable(nameof(Wages_overheadsEntity));
            builder.HasKey(x => x.Id);
        }
    }
}
