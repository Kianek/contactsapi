using ContactsApi.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApi.Tests.Infrastructure
{
    public class CustomWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbServiceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ContactsDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                    options.UseInternalServiceProvider(dbServiceProvider);
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ContactsDbContext>();
                    var logger = scopedServices
                    .GetRequiredService<ILogger<CustomWebAppFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database.
                        SeedData.InitializeDb(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"Error seeding the database. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
