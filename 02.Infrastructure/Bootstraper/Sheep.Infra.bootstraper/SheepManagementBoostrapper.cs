using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Infrastructure.Data;
using Sheep.Infra.Data.Sql;



namespace Sheep.Infra.bootstraper
{
    public static class SheepManagementBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SheepDbcontext>(x => x.UseSqlServer(connectionString));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
