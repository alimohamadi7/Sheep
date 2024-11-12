using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Infrastructure.Data;
using Sheep.Infra.Data.Sql;
using Sheep.Infra.Data.Sql.Category;
using Sheep.Infra.Data.Sql.Sheep.Repository;



namespace Sheep.Infra.bootstraper
{
    public static class SheepManagementBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SheepDbcontext>(x => x.UseSqlServer(connectionString));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISheepRepository, SheepRepository>();
            services.AddTransient<ISheepApplication, SheepApplication>();
            services.AddTransient<ICategoryRepository ,CategoryRepository>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();
        }
    }
}
