﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Core.Application.CategoryPrice;
using Sheep.Core.Application.CategoryPrice.Contracts;
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
            services.AddTransient<ICategoryPriceRepo, CategoryPriceRepo>();
            services.AddTransient<ICategoryPriceApp, CategoryPriceApp>();
            services.AddTransient<ISheepCategoryApplication ,SheepCategoryApplication>();
            services.AddTransient<ISheepCategoryRepository,SheepCategoryRepository>();
        }
    }
}
