using ContactsApi.Infrastructure;
using ContactsApi.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ContactsApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRegistrationService, UserRegistrationService>();

            // Configure Dependencies
            services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<ContactsDbContext>()
                .AddDefaultTokenProviders();
            services.AddDbContext<ContactsDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
