using Microsoft.EntityFrameworkCore;
using Sheep.Framework.Domain.Entities;
using Sheep.Framework.Infrastructure.Utilities;


namespace Sheep.Infra.Data.Sql
{
    public class SheepDbcontext(DbContextOptions<SheepDbcontext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntities<IEntity>(typeof(IEntity).Assembly);
            modelBuilder.ApplyRestrictDeleteBehaviour();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SheepDbcontext).Assembly);
            modelBuilder.AddSequentialGuidForIdConvention();
            base.OnModelCreating(modelBuilder);
        }
    }
}
