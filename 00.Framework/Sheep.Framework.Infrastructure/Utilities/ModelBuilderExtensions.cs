
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sheep.Framework.Infrastructure.Utilities
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterEntities<TEntityType>(this ModelBuilder builder, params Assembly[] assemblies)
        {
            var entityTypes = assemblies
                .SelectMany(c => c.ExportedTypes)
                .Where(c => c is { IsClass: true, IsAbstract: false, IsPublic: true } &&
                            typeof(TEntityType).IsAssignableFrom(c));

            foreach (var entityType in entityTypes)
            {
                builder.Entity(entityType);
            }
        }
        public static void ApplyRestrictDeleteBehaviour(this ModelBuilder modelBuilder)
        {
            var cascadeForeignKeys =
                modelBuilder.Model.GetEntityTypes()
                    .SelectMany(c => c.GetForeignKeys())
                    .Where(c => !c.IsOwnership && c.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var cascadeForeignKey in cascadeForeignKeys)
            {
                cascadeForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public static void AddSequentialGuidForIdConvention(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddDefaultValueSqlConvention("Id", typeof(Guid), "NEWSEQUENTIALID()");
        }
        public static void AddDefaultValueSqlConvention(this ModelBuilder modelBuilder, string propertyName, Type propertyType, string defaultValueSql)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                IMutableProperty property = entityType.GetProperties().SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (property != null && property.ClrType == propertyType)
                    property.SetDefaultValueSql(defaultValueSql);
            }
        }
    }
}
