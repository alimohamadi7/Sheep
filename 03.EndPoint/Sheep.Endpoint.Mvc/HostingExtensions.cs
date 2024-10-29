using Sheep.Infra.bootstraper;

namespace Sheep.Endpoint.Mvc
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("SheepDb");
            SheepManagementBoostrapper.Configure(builder.Services, connectionString);
            builder.Services.AddControllersWithViews();
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            //app.UseElmah();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                _ = app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            return app;
        }

    }
}
