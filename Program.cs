using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MetDashboard.Data;
using MetDashboard.Components;
using Radzen;

namespace MetDashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddRadzenComponents();

            // Connect to RealEstateDB
            var connectionString =
                builder.Configuration.GetConnectionString("RealEstateDatabase")
                ?? throw new InvalidOperationException(
                    "Connection string 'RealEstateDatabase' was not found.");

            builder.Services.AddDbContextFactory<RealEstateDbContext>(options =>
                options.UseMySQL(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute(
                "/not-found",
                createScopeForStatusCodePages: true);

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}