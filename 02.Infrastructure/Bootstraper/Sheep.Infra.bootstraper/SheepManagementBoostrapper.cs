using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sheep.Core.Application.Background;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.Sheep;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.Sheep.Contracts.Repository;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Core.Application.Sheep.SheepCategory.Contracts;
using Sheep.Framework.Application.Cotrats.Data;
using Sheep.Framework.Infrastructure.Data;
using Sheep.Infra.Data.Sql;
using Sheep.Infra.Data.Sql.Category.Repository;
using Sheep.Infra.Data.Sql.CategoryPrice;
using Sheep.Infra.Data.Sql.Sheep.Repository;
using Sheep.Infra.Data.Sql.Sheep.SheepCategory;
using Sheep.Infra.BackgroundTask.Background;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.CategoryPrice;
using Sheep.Core.Application.Wages_overheads.Contracts;
using Sheep.Core.Application.Wages_overheads;
using Sheep.Infra.Data.Sql.Wages_overheads;
using Sheep.Core.Application.Fiscalyear.Contracts;
using Sheep.Core.Application.Fiscalyear;
using Sheep.Infra.Data.Sql.Fiscalyear;
using Sheep.Core.Application.Sheep.PricePeriod;
using Sheep.Core.Application.Sheep.PricePeriod.Contracts;
using Sheep.Infra.Data.Sql.Sheep.PricePeriod.Repository;
using Sheep.Core.Application.Sheep.SheepFullPrice.Contracts;
using Sheep.Infra.Data.Sql.Sheep.SheepFullPrice;
using Sheep.Core.Application.Sheep.SheepFullPrice;


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
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();
            services.AddTransient<ICategoryPriceRepository, CategoryPriceRepo>();
            services.AddTransient<ICategoryPriceApplication, CategoryPriceApplication>();
            services.AddTransient<ISheepCategoryApplication ,SheepCategoryApplication>();
            services.AddTransient<ISheepCategoryRepository,SheepCategoryRepository>();
            services.AddSingleton<IBackgroundJobs, BackgroundJobs>();
            services.AddTransient<IWagesoverheadsApplication,WagesoverheadsApplication>();
            services.AddTransient<IWagesoverheadsRepository,WagesOverheadRepository>();
            services.AddTransient<IFiscalyearApplication, FiscalyearApplication>();
            services.AddTransient<IFiscalyearRepository,FiscalyearRepository>();
            services.AddTransient<ISheepPricePeriodApp, SheepPricePeriodApp>();
            services.AddTransient<ISheepPricePeriodRepo,SheepPricePeriodRepo>();
            services.AddTransient<IFullPriceSheepApplication ,FullPriceSheepApplication>();
            services.AddTransient<IFullPriceSheepRepository,FullPriceSheepRepository>();
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }
    }
}
